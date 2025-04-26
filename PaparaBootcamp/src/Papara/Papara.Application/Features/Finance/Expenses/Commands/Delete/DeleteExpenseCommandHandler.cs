using Base.Application.Common.Helpers;
using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using MediatR;
using Papara.Domain.Entities.Finance;

namespace Papara.Application.Features.Finance.Expenses.Commands.Delete;

public class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommand, Unit>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserContextService _userContextService;
	public DeleteExpenseCommandHandler(IUnitOfWork unitOfWork, IUserContextService userContextService)
	{
		_unitOfWork = unitOfWork;
		_userContextService = userContextService;
	}

	public async Task<Unit> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
	{
		var entity = await _unitOfWork.Repository<Expense>()
			.GetByIdAsync(request.Id, x => x.Approvals);

		if (entity == null)
			throw new KeyNotFoundException("Masraf kaydı bulunamadı.");

		// Masrafın aktif bir approval'ı var mı kontrol et
		var activeApproval = entity.Approvals?.FirstOrDefault(x => x.IsActive);

		if (activeApproval == null)
			throw new InvalidOperationException("Bu masraf için geçerli bir onay kaydı bulunamadı.");

		// Sadece Bekliyor (Pending) statüsünde olanlar silinebilir
		if (activeApproval.Status != Domain.Enums.Finance.ExpenseApprovalStatus.Pending)
			throw new InvalidOperationException("Sadece beklemede olan masraf kayıtları silinebilir.");

		var currentUserRole = _userContextService.GetCurrentUserRole();

		if (currentUserRole == "Employee")
		{
			AuthorizationHelper.EnsureEmployeeOwnsData(_userContextService, entity.EmployeeId);
		}

		_unitOfWork.Repository<Expense>().Delete(entity);
		await _unitOfWork.CommitAsync();

		return Unit.Value;
	}
}
