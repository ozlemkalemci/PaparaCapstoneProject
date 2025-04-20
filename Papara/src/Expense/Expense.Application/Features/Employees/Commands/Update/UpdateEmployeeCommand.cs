using Expense.Application.Features.Employees.Models;
using MediatR;

namespace Expense.Application.Features.Employees.Commands.Update;

public class UpdateEmployeeCommand : IRequest<EmployeeResponseDto>
{
	public long Id { get; set; }
	public UpdateEmployeeRequestDto Request { get; set; }

	public UpdateEmployeeCommand(long id, UpdateEmployeeRequestDto request)
	{
		Id = id;
		Request = request;
	}
}