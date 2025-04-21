using Expense.Application.Features.EmployeeDepartments.Models;
using MediatR;

namespace Expense.Application.Features.EmployeeDepartments.Commands.Update;

public class UpdateEmployeeDepartmentCommand : IRequest<EmployeeDepartmentResponse>
{
	public long Id { get; set; }
	public UpdateEmployeeDepartmentRequest Request { get; set; }
	public UpdateEmployeeDepartmentCommand(long id, UpdateEmployeeDepartmentRequest request)
	{
		Id = id;
		Request = request;
	}
}