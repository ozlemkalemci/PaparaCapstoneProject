using MediatR;

namespace Papara.Application.Features.HR.Employees.Commands.Delete;

public class DeleteEmployeeCommand : IRequest<Unit>
{
	public long Id { get; }

	public DeleteEmployeeCommand(long id)
	{
		Id = id;
	}
}