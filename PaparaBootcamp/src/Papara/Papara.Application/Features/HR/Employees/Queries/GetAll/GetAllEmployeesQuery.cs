using MediatR;
using Papara.Application.Features.HR.Employees.Models;

namespace Papara.Application.Features.HR.Employees.Queries.GetAll;

public class GetAllEmployeesQuery : IRequest<List<EmployeeResponse>>
{
	public GetEmployeeRequest Request { get; set; }

	public GetAllEmployeesQuery(GetEmployeeRequest request)
	{
		Request = request;
	}
}