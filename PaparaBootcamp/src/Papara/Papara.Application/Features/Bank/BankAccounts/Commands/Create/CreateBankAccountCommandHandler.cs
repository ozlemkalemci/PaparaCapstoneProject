using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.Bank.BankAccounts.Converters;
using Papara.Application.Features.Bank.BankAccounts.Models;
using Papara.Domain.Entities.Bank;

namespace Papara.Application.Features.Bank.BankAccounts.Commands.Create;

public class CreateBankAccountCommandHandler : IRequestHandler<CreateBankAccountCommand, BankAccountResponse>
{
	private readonly IBankUnitOfWork _bankUnitOfWork;

	public CreateBankAccountCommandHandler(IBankUnitOfWork bankUnitOfWork)
	{
		_bankUnitOfWork = bankUnitOfWork;
	}

	public async Task<BankAccountResponse> Handle(CreateBankAccountCommand request, CancellationToken cancellationToken)
	{
		var dto = request.Request;

		var entity = new BankAccount
		{
			AccountHolderName = dto.AccountHolderName,
			IBAN = dto.IBAN,
			IdentityNumber = dto.IdentityNumber,
			TaxNumber = dto.TaxNumber,
			AccountType = dto.AccountType
		};

		await _bankUnitOfWork.Repository<BankAccount>().AddAsync(entity);
		await _bankUnitOfWork.CommitAsync();

		return BankAccountConverters.BankAccountConverter(entity);
	}
}
