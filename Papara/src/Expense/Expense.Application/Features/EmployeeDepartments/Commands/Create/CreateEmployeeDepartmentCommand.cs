using Expense.Application.Features.EmployeeDepartments.Models;
using MediatR;

namespace Expense.Application.Features.EmployeeDepartments.Commands.Create;

public class CreateEmployeeDepartmentCommand : IRequest<EmployeeDepartmentResponse>
{
	public CreateEmployeeDepartmentRequest Request { get; set; }

	public CreateEmployeeDepartmentCommand(CreateEmployeeDepartmentRequest request)
	{
		Request = request;
	}
}