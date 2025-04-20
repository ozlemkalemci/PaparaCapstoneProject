using Base.Application.Common.Extensions;
using Base.Domain.Interfaces;
using Expense.Application.Features.Employees.Converters;
using Expense.Application.Features.Employees.Models;
using Expense.Domain.Entities;
using MediatR;
using System.Linq.Expressions;

namespace Expense.Application.Features.Employees.Queries.GetAll;

public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, List<EmployeeResponseDto>>
{
	private readonly IUnitOfWork _unitOfWork;

	public GetAllEmployeesQueryHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<List<EmployeeResponseDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
	{
		var filter = (Expression<Func<Employee, bool>>)(x => x.IsActive);
		var includes = new List<Expression<Func<Employee, object>>>();

		if (request.Request.DepartmentId.HasValue)
		{
			filter = filter.And(x => x.DepartmentId == request.Request.DepartmentId.Value);
		}

		if (request.Request.IncludeDepartment)
		{
			includes.Add(x => x.Department);
		}

		if (request.Request.IncludeUser)
		{
			includes.Add(x => x.User);
		}
		
		if (request.Request.IncludePhones)
		{
			includes.Add(x => x.Phones);
		}
		
		if (request.Request.IncludeAddresses)
		{
			includes.Add(x => x.Addresses);
		}

		var employees = await _unitOfWork.Repository<Employee>()
			.GetAllAsync(filter, includes.ToArray());

		return EmployeeConverters.EmployeeConverterList(employees);
	}
}
