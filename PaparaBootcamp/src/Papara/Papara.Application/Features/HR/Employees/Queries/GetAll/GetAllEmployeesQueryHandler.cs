using Base.Application.Common.Extensions;
using Base.Domain.Interfaces;
using MediatR;
using System.Linq.Expressions;
using Papara.Application.Features.HR.Employees.Converters;
using Papara.Application.Features.HR.Employees.Models;
using Papara.Domain.Entities.HR;
using Base.Domain.Enums;
using Base.Application.Interfaces;

namespace Papara.Application.Features.HR.Employees.Queries.GetAll;

public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, List<EmployeeResponse>>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserContextService _userContextService;

	public GetAllEmployeesQueryHandler(IUnitOfWork unitOfWork, IUserContextService userContextService)
	{
		_unitOfWork = unitOfWork;
		_userContextService = userContextService;
	}

	public async Task<List<EmployeeResponse>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
	{
		var filter = (Expression<Func<Employee, bool>>)(x => x.IsActive);
		var includes = new List<Expression<Func<Employee, object>>>();
		var currentEmpId = _userContextService.GetCurrentEmployeeId();
		string currentUserRole = _userContextService.GetCurrentUserRole();
		string empRole = UserRole.Employee.ToString();

		if (currentEmpId > 0 && currentUserRole == empRole)
		{
			filter = filter.And(x => x.Id == currentEmpId);
		}

		if (request.Request.DepartmentId > 0)
		{
			filter = filter.And(x => x.DepartmentId == request.Request.DepartmentId);

		}
		if (request.Request.IncludeDepartment)
		{
			includes.Add(x => x.Department);
		}

		if (request.Request.IncludeUser)
		{
			includes.Add(x => x.User);
		}

		var employees = await _unitOfWork.Repository<Employee>()
			.GetAllAsync(filter, includes.ToArray());

		return EmployeeConverters.EmployeeConverterList(employees);
	}
}
