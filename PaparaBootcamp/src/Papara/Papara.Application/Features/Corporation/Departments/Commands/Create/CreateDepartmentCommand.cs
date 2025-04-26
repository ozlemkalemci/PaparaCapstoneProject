using MediatR;
using Papara.Application.Features.Corporation.Departments.Models;

namespace Papara.Application.Features.Corporation.Departments.Commands.Create;

public class CreateDepartmentCommand : IRequest<DepartmentResponse>
{
	public CreateDepartmentRequest Request { get; set; }

	public CreateDepartmentCommand(CreateDepartmentRequest request)
	{
		Request = request;
	}
}