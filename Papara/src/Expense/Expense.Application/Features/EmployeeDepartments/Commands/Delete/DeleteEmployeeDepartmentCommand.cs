using MediatR;

namespace Expense.Application.Features.EmployeeDepartments.Commands.Delete;

public class DeleteEmployeeDepartmentCommand : IRequest<Unit>
{
	public long Id { get; }
	public DeleteEmployeeDepartmentCommand(long id)
	{
		Id = id;
	}
}