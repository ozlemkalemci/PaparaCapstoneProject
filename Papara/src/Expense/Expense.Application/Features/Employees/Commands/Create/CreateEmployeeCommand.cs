using MediatR;
using Expense.Application.Features.Employees.Models;

namespace Expense.Application.Features.Employees.Commands.Create;

public class CreateEmployeeCommand : IRequest<EmployeeResponse>
{
	public CreateEmployeeRequest Request { get; set; }

	public CreateEmployeeCommand(CreateEmployeeRequest request)
	{
		Request = request;
	}
}