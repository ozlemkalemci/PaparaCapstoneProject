using MediatR;

namespace Papara.Application.Features.Corporation.Departments.Commands.Delete;

public class DeleteDepartmentCommand : IRequest<Unit>
{
	public long Id { get; }
	public DeleteDepartmentCommand(long id)
	{
		Id = id;
	}
}