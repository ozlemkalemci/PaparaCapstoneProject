using Base.Domain.Interfaces;
using MediatR;
using Papara.Domain.Entities.Finance;

namespace Papara.Application.Features.Finance.ExpenseTypes.Commands.Delete;

public class DeleteExpenseTypeCommandHandler : IRequestHandler<DeleteExpenseTypeCommand, Unit>
{
	private readonly IUnitOfWork _unitOfWork;

	public DeleteExpenseTypeCommandHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<Unit> Handle(DeleteExpenseTypeCommand request, CancellationToken cancellationToken)
	{
		var expenseType = await _unitOfWork.Repository<ExpenseType>().GetByIdAsync(request.Id);

		if (expenseType == null)
			throw new KeyNotFoundException("Masraf kategorisi bulunamadı.");

		// Bu ExpenseType'a bağlı aktif masraf var mı kontrolü
		var hasActiveExpenses = await _unitOfWork.Repository<Expense>()
			.AnyAsync(e => e.ExpenseTypeId == request.Id && e.IsActive);

		if (hasActiveExpenses)
			throw new InvalidOperationException("Bu masraf kategorisine bağlı aktif masraf kayıtları mevcut. Önce bu masrafları silmelisiniz.");

		_unitOfWork.Repository<ExpenseType>().Delete(expenseType);
		await _unitOfWork.CommitAsync();

		return Unit.Value;
	}
}
