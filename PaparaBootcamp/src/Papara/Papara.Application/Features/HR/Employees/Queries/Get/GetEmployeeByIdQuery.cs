using MediatR;
using Papara.Application.Features.HR.Employees.Models;

namespace Papara.Application.Features.HR.Employees.Queries.Get;

public class GetEmployeeByIdQuery : IRequest<EmployeeResponse>
{
	public long Id { get; set; }

	public GetEmployeeByIdQuery(long id)
	{
		Id = id;
	}
}