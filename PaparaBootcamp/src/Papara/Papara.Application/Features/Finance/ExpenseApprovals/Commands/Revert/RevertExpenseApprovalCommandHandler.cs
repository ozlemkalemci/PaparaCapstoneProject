using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.Finance.ExpenseApprovals.Converters;
using Papara.Application.Features.Finance.ExpenseApprovals.Models;
using Papara.Domain.Entities.Finance;
using Papara.Domain.Enums.Finance;

namespace Papara.Application.Features.Finance.ExpenseApprovals.Commands.Revert;

public class RevertExpenseApprovalCommandHandler : IRequestHandler<RevertExpenseApprovalCommand, ExpenseApprovalResponse>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserContextService _userContextService;

	public RevertExpenseApprovalCommandHandler(IUnitOfWork unitOfWork, IUserContextService userContextService)
	{
		_unitOfWork = unitOfWork;
		_userContextService = userContextService;
	}

	public async Task<ExpenseApprovalResponse> Handle(RevertExpenseApprovalCommand request, CancellationToken cancellationToken)
	{
		using var transaction = _unitOfWork.BeginTransaction();

		try
		{
			var approval = await _unitOfWork.Repository<ExpenseApproval>().GetByIdAsync(request.Id);

			if (approval == null)
				throw new KeyNotFoundException("Onay kaydı bulunamadı.");

			if (approval.Status == ExpenseApprovalStatus.Pending)
				throw new InvalidOperationException("Beklemede olan bir kayıt revert edilemez.");

			if (!approval.IsActive)
				throw new InvalidOperationException("Zaten pasif bir onay kaydı revert edilemez.");

			// Şu anki onay kaydını soft delete yap
			_unitOfWork.Repository<ExpenseApproval>().Delete(approval);

			// Yeni bekleyen onay kaydını oluştur
			var newApproval = new ExpenseApproval
			{
				ExpenseId = approval.ExpenseId,
				Status = ExpenseApprovalStatus.Pending,
				Description = request.Description ?? "Masraf kaydı revert edilerek tekrar beklemeye alındı.",
				CreatedById = _userContextService.GetCurrentUserId() ?? 0,
				CreatedDate = DateTimeOffset.UtcNow,
				IsActive = true
			};

			await _unitOfWork.Repository<ExpenseApproval>().AddAsync(newApproval);

			await _unitOfWork.CommitAsync();
			await transaction.CommitAsync();

			return ExpenseApprovalConverters.ExpenseApprovalConverter(newApproval);
		}
		catch
		{
			await transaction.RollbackAsync();
			throw;
		}
	}
}

	
			
