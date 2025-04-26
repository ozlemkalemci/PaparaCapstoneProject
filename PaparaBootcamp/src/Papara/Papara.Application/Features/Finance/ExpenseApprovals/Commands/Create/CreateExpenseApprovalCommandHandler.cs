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
			var existingApprovals = await _unitOfWork.Repository<ExpenseApproval>()
				.Where(x => x.ExpenseId == dto.ExpenseId && x.IsActive);

			var activeApproval = existingApprovals.FirstOrDefault();

			if (activeApproval != null)
			{
				if (activeApproval.Status == ExpenseApprovalStatus.Pending)
				{
					// Eğer aktif ve beklemede bir kayıt varsa, onu soft delete yap
					_unitOfWork.Repository<ExpenseApproval>().Delete(activeApproval);
				}
				else
				{
					// Eğer mevcut aktif kayıt zaten sonuçlanmışsa, yeni kayıt oluşturulamaz
					throw new InvalidOperationException("Bu masraf kaydı zaten sonuçlanmış. Yeni bir onay kaydı oluşturulamaz.");
				}
			}

			// Yeni approval kaydını oluştur
			var entity = new ExpenseApproval
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

			await _unitOfWork.Repository<ExpenseApproval>().AddAsync(entity);
			await _unitOfWork.CommitAsync();
			await transaction.CommitAsync();

			return ExpenseApprovalConverters.ExpenseApprovalConverter(entity);
		}
		catch (Exception)
		{
			await transaction.RollbackAsync();
			throw;
		}
	}
}
