using Expense.Application.Features.EmployeeDepartments.Models;
using MediatR;

namespace Expense.Application.Features.EmployeeDepartments.Queries.Get;

public class GetEmployeeDepartmentByIdQuery : IRequest<EmployeeDepartmentResponse>
{
	public long Id { get; set; }

	public GetEmployeeDepartmentByIdQuery(long id)
	{
		Id = id;
	}
}