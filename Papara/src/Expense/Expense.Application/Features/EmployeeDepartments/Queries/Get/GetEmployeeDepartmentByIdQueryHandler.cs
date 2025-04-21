using Base.Domain.Interfaces;
using Expense.Application.Features.EmployeeDepartments.Converters;
using Expense.Application.Features.EmployeeDepartments.Models;
using Expense.Domain.Entities;
using MediatR;

namespace Expense.Application.Features.EmployeeDepartments.Queries.Get;

public class GetEmployeeDepartmentByIdQueryHandler : IRequestHandler<GetEmployeeDepartmentByIdQuery, EmployeeDepartmentResponse>
{
	private readonly IUnitOfWork _unitOfWork;

	public GetEmployeeDepartmentByIdQueryHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<EmployeeDepartmentResponse> Handle(GetEmployeeDepartmentByIdQuery request, CancellationToken cancellationToken)
	{
		var EmployeeDepartment = await _unitOfWork.Repository<EmployeeDepartment>().GetByIdAsync(request.Id);

		if (EmployeeDepartment == null)
			throw new KeyNotFoundException("Departman bulunamadı.");

		return EmployeeDepartmentConverters.EmployeeDepartmentConverter(EmployeeDepartment);
	}
}