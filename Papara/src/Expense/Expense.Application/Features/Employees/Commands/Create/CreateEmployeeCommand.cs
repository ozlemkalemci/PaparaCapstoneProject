using MediatR;
using Expense.Application.Features.Employees.Models;

namespace Expense.Application.Features.Employees.Commands.Create;

public class CreateEmployeeCommand : IRequest<EmployeeResponseDto>
{
	public EmployeeRequestDto Request { get; set; }

	public CreateEmployeeCommand(EmployeeRequestDto request)
	{
		Request = request;
	}
}