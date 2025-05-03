using MediatR;

namespace Papara.Application.Features.Bank.BankAccounts.Commands.Delete;

public class DeleteBankAccountCommand : IRequest<Unit>
{
	public long Id { get; set; }

	public DeleteBankAccountCommand(long id)
	{
		Id = id;
	}
}