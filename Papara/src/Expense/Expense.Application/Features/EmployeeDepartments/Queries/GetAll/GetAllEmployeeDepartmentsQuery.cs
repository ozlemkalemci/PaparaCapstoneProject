using Expense.Application.Features.EmployeeDepartments.Models;
using MediatR;

namespace Expense.Application.Features.EmployeeDepartments.Queries.GetAll;

public class GetAllEmployeeDepartmentsQuery : IRequest<List<EmployeeDepartmentResponse>>
{
	public GetEmployeeDepartmentRequest Request { get; set; }

	public GetAllEmployeeDepartmentsQuery(GetEmployeeDepartmentRequest request)
	{
		Request = request;
	}
}