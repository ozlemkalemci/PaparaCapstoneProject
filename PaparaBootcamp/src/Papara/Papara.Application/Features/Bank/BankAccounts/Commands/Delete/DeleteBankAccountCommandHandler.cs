using Base.Domain.Interfaces;
using MediatR;
using Papara.Domain.Entities.Bank;

namespace Papara.Application.Features.Bank.BankAccounts.Commands.Delete;

public class DeleteBankAccountCommandHandler : IRequestHandler<DeleteBankAccountCommand, Unit>
{
	private readonly IBankUnitOfWork _bankUnitOfWork;

	public DeleteBankAccountCommandHandler(IBankUnitOfWork bankUnitOfWork)
	{
		_bankUnitOfWork = bankUnitOfWork;
	}

	public async Task<Unit> Handle(DeleteBankAccountCommand request, CancellationToken cancellationToken)
	{
		var entity = await _bankUnitOfWork.Repository<BankAccount>().GetByIdAsync(request.Id);

		if (entity == null)
			throw new KeyNotFoundException("Banka hesabı bulunamadı.");

		_bankUnitOfWork.Repository<BankAccount>().Delete(entity);
		await _bankUnitOfWork.CommitAsync();

		return Unit.Value;
	}
}
