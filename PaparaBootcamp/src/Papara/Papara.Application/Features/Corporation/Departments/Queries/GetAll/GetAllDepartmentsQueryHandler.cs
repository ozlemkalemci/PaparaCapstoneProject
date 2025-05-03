using Base.Application.Common.Extensions;
using Base.Domain.Interfaces;
using MediatR;
using System.Linq.Expressions;
using Papara.Application.Features.Corporation.Departments.Converters;
using Papara.Application.Features.Corporation.Departments.Models;
using Papara.Domain.Entities.Corporation;

namespace Papara.Application.Features.Corporation.Departments.Queries.GetAll;

public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery, List<DepartmentResponse>>
{
	private readonly IUnitOfWork _unitOfWork;

	public GetAllDepartmentsQueryHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<List<DepartmentResponse>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
	{
		var filter = (Expression<Func<Department, bool>>)(x => x.IsActive);
		var includes = new List<Expression<Func<Department, object>>>();

		var Departments = await _unitOfWork.Repository<Department>()
			.GetAllAsync(filter, includes.ToArray());

		return DepartmentConverters.DepartmentConverterList(Departments);
	}
}