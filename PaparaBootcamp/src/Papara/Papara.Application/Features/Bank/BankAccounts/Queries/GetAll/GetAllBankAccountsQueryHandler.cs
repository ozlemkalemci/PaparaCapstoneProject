using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.Bank.BankAccounts.Converters;
using Papara.Application.Features.Bank.BankAccounts.Models;
using Papara.Domain.Entities.Bank;

namespace Papara.Application.Features.Bank.BankAccounts.Queries.GetAll;

public class GetAllBankAccountsQueryHandler : IRequestHandler<GetAllBankAccountsQuery, List<BankAccountResponse>>
{
	private readonly IBankUnitOfWork _bankUnitOfWork;

	public GetAllBankAccountsQueryHandler(IBankUnitOfWork bankUnitOfWork)
	{
		_bankUnitOfWork = bankUnitOfWork;
	}

	public async Task<List<BankAccountResponse>> Handle(GetAllBankAccountsQuery request, CancellationToken cancellationToken)
	{
		var entities = await _bankUnitOfWork.Repository<BankAccount>().GetAllAsync();

		return BankAccountConverters.BankAccountConverterList(entities);
	}
}
