using MediatR;
using Papara.Application.Features.Bank.BankAccounts.Models;

namespace Papara.Application.Features.Bank.BankAccounts.Commands.Update;

public class UpdateBankAccountCommand : IRequest<BankAccountResponse>
{
	public long Id { get; set; }
	public UpdateBankAccountRequest Request { get; set; }

	public UpdateBankAccountCommand(long id, UpdateBankAccountRequest request)
	{
		Id = id;
		Request = request;
	}
}