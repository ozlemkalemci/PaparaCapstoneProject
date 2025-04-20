using MediatR;

namespace Expense.Application.Features.Employees.Commands.Delete;

public class DeleteEmployeeCommand : IRequest<Unit>
{
	public long Id { get; }

	public DeleteEmployeeCommand(long id)
	{
		Id = id;
	}
}