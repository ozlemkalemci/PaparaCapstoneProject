using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.Finance.ExpenseApprovals.Converters;
using Papara.Application.Features.Finance.ExpenseApprovals.Models;
using Papara.Domain.Entities.Finance;
using Papara.Domain.Enums.Finance;

namespace Papara.Application.Features.Finance.ExpenseApprovals.Commands.Create;

public class CreateExpenseApprovalCommandHandler : IRequestHandler<CreateExpenseApprovalCommand, ExpenseApprovalResponse>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserContextService _userContextService;

	public CreateExpenseApprovalCommandHandler(IUnitOfWork unitOfWork, IUserContextService userContextService)
	{
		_unitOfWork = unitOfWork;
		_userContextService = userContextService;
	}

	public async Task<ExpenseApprovalResponse> Handle(CreateExpenseApprovalCommand request, CancellationToken cancellationToken)
	{
		var dto = request.Request;

		using var transaction = _unitOfWork.BeginTransaction();
		try
		{
			await EnsureNoConcludedApprovalExistsAsync(dto.ExpenseId); //beklemede olan önce soft delete yapılıyor çünkü geçmişe dair bilgilere erişmek isteyebiliriz.
			var approval = await CreateApprovalAsync(dto);
			await MarkExpenseAsConcludedAsync(dto.ExpenseId);

			await _unitOfWork.CommitAsync();
			await transaction.CommitAsync();

			return ExpenseApprovalConverters.ExpenseApprovalConverter(approval);
		}
		catch
		{
			await transaction.RollbackAsync();
			throw;
		}
	}

	private async Task EnsureNoConcludedApprovalExistsAsync(long expenseId)
	{
		var approvals = await _unitOfWork.Repository<ExpenseApproval>()
			.Where(x => x.ExpenseId == expenseId && x.IsActive);

		var existing = approvals.FirstOrDefault();

		if (existing is not null)
		{
			if (existing.Status == ExpenseApprovalStatus.Pending)
				_unitOfWork.Repository<ExpenseApproval>().Delete(existing);
			else
				throw new InvalidOperationException("Bu masraf kaydı zaten sonuçlanmış. Yeni bir onay kaydı oluşturulamaz.");
		}
	}

	private async Task<ExpenseApproval> CreateApprovalAsync(CreateExpenseApprovalRequest dto)
	{
		var approval = new ExpenseApproval
		{
			ExpenseId = dto.ExpenseId,
			Status = dto.Status,
			Description = dto.Description,
			ApprovedById = _userContextService.GetCurrentUserId(),
			ApprovedDate = DateTimeOffset.UtcNow,
			CreatedDate = DateTimeOffset.UtcNow,
			CreatedById = _userContextService.GetCurrentUserId() ?? 0,
			IsActive = true
		};

		await _unitOfWork.Repository<ExpenseApproval>().AddAsync(approval);
		return approval;
	}

	private async Task MarkExpenseAsConcludedAsync(long expenseId)
	{
		var expense = await _unitOfWork.Repository<Expense>().GetByIdAsync(expenseId);
		if (expense != null)
		{
			expense.Concluded = true;
			_unitOfWork.Repository<Expense>().Update(expense);
		}
	}
}
