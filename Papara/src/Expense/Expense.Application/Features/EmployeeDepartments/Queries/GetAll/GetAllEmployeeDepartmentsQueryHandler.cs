using Base.Application.Common.Extensions;
using Base.Domain.Interfaces;
using Expense.Application.Features.EmployeeDepartments.Converters;
using Expense.Application.Features.EmployeeDepartments.Models;
using Expense.Domain.Entities;
using MediatR;
using System.Linq.Expressions;

namespace Expense.Application.Features.EmployeeDepartments.Queries.GetAll;

public class GetAllEmployeeDepartmentsQueryHandler : IRequestHandler<GetAllEmployeeDepartmentsQuery, List<EmployeeDepartmentResponse>>
{
	private readonly IUnitOfWork _unitOfWork;

	public GetAllEmployeeDepartmentsQueryHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<List<EmployeeDepartmentResponse>> Handle(GetAllEmployeeDepartmentsQuery request, CancellationToken cancellationToken)
	{
		var filter = (Expression<Func<EmployeeDepartment, bool>>)(x => x.IsActive);
		var includes = new List<Expression<Func<EmployeeDepartment, object>>>();

		if (!string.IsNullOrWhiteSpace(request.Request.DepartmentName))
		{
			filter = filter.And(x => x.DepartmentName.Contains(request.Request.DepartmentName));
		}

		var EmployeeDepartments = await _unitOfWork.Repository<EmployeeDepartment>()
			.GetAllAsync(filter, includes.ToArray());

		return EmployeeDepartmentConverters.EmployeeDepartmentConverterList(EmployeeDepartments);
	}
}