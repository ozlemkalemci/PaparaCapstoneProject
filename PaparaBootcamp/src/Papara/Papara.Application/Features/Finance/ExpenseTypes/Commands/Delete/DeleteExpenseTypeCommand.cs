using MediatR;

namespace Papara.Application.Features.Finance.ExpenseTypes.Commands.Delete;

public class DeleteExpenseTypeCommand : IRequest<Unit>
{
	public long Id { get; }

	public DeleteExpenseTypeCommand(long id)
	{
		Id = id;
	}
}
