using MediatR;

namespace Papara.Application.Features.Finance.Expenses.Commands.Delete;

public class DeleteExpenseCommand : IRequest<Unit>
{
	public long Id { get; }

	public DeleteExpenseCommand(long id)
	{
		Id = id;
	}
}
