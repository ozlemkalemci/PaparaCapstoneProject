using Expense.Application.Features.Employees.Models;
using MediatR;

namespace Expense.Application.Features.Employees.Queries.GetAll;

public class GetAllEmployeesQuery : IRequest<List<EmployeeResponseDto>>
{
	public GetEmployeeQueryRequest Request { get; set; }

	public GetAllEmployeesQuery(GetEmployeeQueryRequest request)
	{
		Request = request;
	}
}