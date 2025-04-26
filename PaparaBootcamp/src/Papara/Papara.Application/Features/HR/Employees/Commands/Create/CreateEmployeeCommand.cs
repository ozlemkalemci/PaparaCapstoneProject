using MediatR;
using Papara.Application.Features.HR.Employees.Models;

namespace Papara.Application.Features.HR.Employees.Commands.Create;

public class CreateEmployeeCommand : IRequest<EmployeeResponse>
{
	public CreateEmployeeRequest Request { get; set; }

	public CreateEmployeeCommand(CreateEmployeeRequest request)
	{
		Request = request;
	}
}