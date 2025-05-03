using MediatR;
using Papara.Application.Features.Bank.BankAccounts.Models;

namespace Papara.Application.Features.Bank.BankAccounts.Commands.Create;

public class CreateBankAccountCommand : IRequest<BankAccountResponse>
{
	public CreateBankAccountRequest Request { get; set; }

	public CreateBankAccountCommand(CreateBankAccountRequest request)
	{
		Request = request;
	}
}