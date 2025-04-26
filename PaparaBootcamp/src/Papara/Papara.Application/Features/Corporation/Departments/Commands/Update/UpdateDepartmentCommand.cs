using MediatR;
using Papara.Application.Features.Corporation.Departments.Models;

namespace Papara.Application.Features.Corporation.Departments.Commands.Update;

public class UpdateDepartmentCommand : IRequest<DepartmentResponse>
{
	public long Id { get; set; }
	public UpdateDepartmentRequest Request { get; set; }
	public UpdateDepartmentCommand(long id, UpdateDepartmentRequest request)
	{
		Id = id;
		Request = request;
	}
}