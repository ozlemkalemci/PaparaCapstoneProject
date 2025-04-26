using Base.Domain.Interfaces;
using MediatR;
using Papara.Domain.Entities.Finance;

namespace Papara.Application.Features.Finance.Expenses.Commands.Delete;

public class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommand, Unit>
{
	private readonly IUnitOfWork _unitOfWork;

	public DeleteExpenseCommandHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<Unit> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
	{
		var expense = await _unitOfWork.Repository<Expense>()
			.GetByIdAsync(request.Id, x => x.Approvals);

		if (expense == null)
			throw new KeyNotFoundException("Masraf kaydı bulunamadı.");

		// Masrafın aktif bir approval'ı var mı kontrol et
		var activeApproval = expense.Approvals?.FirstOrDefault(x => x.IsActive);

		if (activeApproval == null)
			throw new InvalidOperationException("Bu masraf için geçerli bir onay kaydı bulunamadı.");

		// Sadece Bekliyor (Pending) statüsünde olanlar silinebilir
		if (activeApproval.Status != Domain.Enums.Finance.ExpenseApprovalStatus.Pending)
			throw new InvalidOperationException("Sadece beklemede olan masraf kayıtları silinebilir.");

		_unitOfWork.Repository<Expense>().Delete(expense);
		await _unitOfWork.CommitAsync();

		return Unit.Value;
	}
}
