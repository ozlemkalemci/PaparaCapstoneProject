using Expense.Application.Features.Employees.Models;
using MediatR;

namespace Expense.Application.Features.Employees.Queries.GetAll;

public class GetAllEmployeesQuery : IRequest<List<EmployeeResponse>>
{
	public GetEmployeeRequest Request { get; set; }

	public GetAllEmployeesQuery(GetEmployeeRequest request)
	{
		Request = request;
	}
}