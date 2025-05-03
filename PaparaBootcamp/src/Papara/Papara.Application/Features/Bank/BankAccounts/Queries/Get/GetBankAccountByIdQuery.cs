using MediatR;
using Papara.Application.Features.Bank.BankAccounts.Models;

namespace Papara.Application.Features.Bank.BankAccounts.Queries.Get;

public class GetBankAccountByIdQuery : IRequest<BankAccountResponse>
{
	public long Id { get; set; }

	public GetBankAccountByIdQuery(long id)
	{
		Id = id;
	}
}