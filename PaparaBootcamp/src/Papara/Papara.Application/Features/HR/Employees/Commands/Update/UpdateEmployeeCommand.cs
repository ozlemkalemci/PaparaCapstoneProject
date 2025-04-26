using MediatR;
using Papara.Application.Features.HR.Employees.Models;

namespace Papara.Application.Features.HR.Employees.Commands.Update;

public class UpdateEmployeeCommand : IRequest<EmployeeResponse>
{
	public long Id { get; set; }
	public UpdateEmployeeRequest Request { get; set; }

	public UpdateEmployeeCommand(long id, UpdateEmployeeRequest request)
	{
		Id = id;
		Request = request;
	}
}