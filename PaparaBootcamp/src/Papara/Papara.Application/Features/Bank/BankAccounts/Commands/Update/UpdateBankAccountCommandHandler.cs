using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.Bank.BankAccounts.Converters;
using Papara.Application.Features.Bank.BankAccounts.Models;
using Papara.Domain.Entities.Bank;

namespace Papara.Application.Features.Bank.BankAccounts.Commands.Update;

public class UpdateBankAccountCommandHandler : IRequestHandler<UpdateBankAccountCommand, BankAccountResponse>
{
	private readonly IBankUnitOfWork _bankUnitOfWork;

	public UpdateBankAccountCommandHandler(IBankUnitOfWork bankUnitOfWork)
	{
		_bankUnitOfWork = bankUnitOfWork;
	}

	public async Task<BankAccountResponse> Handle(UpdateBankAccountCommand request, CancellationToken cancellationToken)
	{
		var entity = await _bankUnitOfWork.Repository<BankAccount>().GetByIdAsync(request.Id);

		if (entity == null)
			throw new KeyNotFoundException("Banka hesabı bulunamadı.");

		var dto = request.Request;

		entity.AccountHolderName = dto.AccountHolderName;
		entity.IBAN = dto.IBAN;
		entity.IdentityNumber = dto.IdentityNumber;
		entity.TaxNumber = dto.TaxNumber;
		entity.AccountType = dto.AccountType;

		_bankUnitOfWork.Repository<BankAccount>().Update(entity);
		await _bankUnitOfWork.CommitAsync();

		return BankAccountConverters.BankAccountConverter(entity);
	}
}
