using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.Finance.Expenses.Converters;
using Papara.Application.Features.Finance.Expenses.Models;
using Papara.Domain.Entities.Finance;
using Papara.Domain.Enums.Finance;

namespace Papara.Application.Features.Finance.Expenses.Commands.Create;

public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, ExpenseResponse>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserContextService _userContextService;

	public CreateExpenseCommandHandler(IUnitOfWork unitOfWork, IUserContextService userContextService)
	{
		_unitOfWork = unitOfWork;
		_userContextService = userContextService;
	}

	public async Task<ExpenseResponse> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
	{
		var dto = request.Request;
		var currentUserId = _userContextService.GetCurrentUserId();
		var currentUserRole = _userContextService.GetCurrentUserRole();

		if (currentUserRole == "Employee")
		{
			dto.EmployeeId = currentUserId ?? throw new UnauthorizedAccessException("Kullanıcı bilgisi bulunamadı.");
		}


		using var transaction = _unitOfWork.BeginTransaction();

		try
		{
			// Expense oluştur
			var expense = new Expense
			{
				EmployeeId = dto.EmployeeId,
				Amount = dto.Amount,
				Description = dto.Description,
				ExpenseDate = dto.ExpenseDate,
				ExpenseTypeId = dto.ExpenseTypeId,
				CreatedDate = DateTimeOffset.UtcNow,
				CreatedById = _userContextService.GetCurrentUserId() ?? 0,
				IsActive = true
			};

			await _unitOfWork.Repository<Expense>().AddAsync(expense);
			await _unitOfWork.CommitAsync();

			// ExpenseApproval sistem tarafından beklemede olarak oluşuyor:
			var approval = new ExpenseApproval
			{
				ExpenseId = expense.Id,
				Status = ExpenseApprovalStatus.Pending, // Bekliyor
				Description = "Masraf kaydı oluşturuldu, onay bekliyor.",
				ApprovedById = null,
				ApprovedDate = null,
				CreatedDate = DateTimeOffset.UtcNow,
				CreatedById = 0,
				IsActive = true
			};

			await _unitOfWork.Repository<ExpenseApproval>().AddAsync(approval);
			await _unitOfWork.CommitAsync();

			await transaction.CommitAsync();

			return ExpenseConverters.ExpenseConverter(expense);
		}
		catch (Exception)
		{
			await transaction.RollbackAsync();
			throw;
		}
	}
}
