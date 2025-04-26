using MediatR;
using Papara.Application.Features.Corporation.Departments.Models;

namespace Papara.Application.Features.Corporation.Departments.Queries.GetAll;

public class GetAllDepartmentsQuery : IRequest<List<DepartmentResponse>>
{
	public GetDepartmentRequest Request { get; set; }

	public GetAllDepartmentsQuery(GetDepartmentRequest request)
	{
		Request = request;
	}
}