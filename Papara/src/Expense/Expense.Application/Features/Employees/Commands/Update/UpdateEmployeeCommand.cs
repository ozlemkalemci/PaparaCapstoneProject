using Expense.Application.Features.Employees.Models;
using MediatR;

namespace Expense.Application.Features.Employees.Commands.Update;

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