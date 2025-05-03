using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.Bank.BankAccounts.Converters;
using Papara.Application.Features.Bank.BankAccounts.Models;
using Papara.Domain.Entities.Bank;

namespace Papara.Application.Features.Bank.BankAccounts.Queries.Get;

public class GetBankAccountByIdQueryHandler : IRequestHandler<GetBankAccountByIdQuery, BankAccountResponse>
{
	private readonly IBankUnitOfWork _bankUnitOfWork;

	public GetBankAccountByIdQueryHandler(IBankUnitOfWork bankUnitOfWork)
	{
		_bankUnitOfWork = bankUnitOfWork;
	}

	public async Task<BankAccountResponse> Handle(GetBankAccountByIdQuery request, CancellationToken cancellationToken)
	{
		var entity = await _bankUnitOfWork.Repository<BankAccount>().GetByIdAsync(request.Id);

		if (entity == null)
			throw new KeyNotFoundException("Banka hesabı bulunamadı.");

		return BankAccountConverters.BankAccountConverter(entity);
	}
}
