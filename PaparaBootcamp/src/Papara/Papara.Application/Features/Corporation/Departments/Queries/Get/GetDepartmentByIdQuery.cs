using MediatR;
using Papara.Application.Features.Corporation.Departments.Models;

namespace Papara.Application.Features.Corporation.Departments.Queries.Get;

public class GetDepartmentByIdQuery : IRequest<DepartmentResponse>
{
	public long Id { get; set; }

	public GetDepartmentByIdQuery(long id)
	{
		Id = id;
	}
}