using Expense.Application.Features.Employees.Models;
using MediatR;

namespace Expense.Application.Features.Employees.Queries.Get;

public class GetEmployeeByIdQuery : IRequest<EmployeeResponse>
{
	public long Id { get; set; }

	public GetEmployeeByIdQuery(long id)
	{
		Id = id;
	}
}