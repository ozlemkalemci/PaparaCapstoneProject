using Base.Domain.Interfaces;
using Expense.Application.Features.Employees.Converters;
using Expense.Application.Features.Employees.Models;
using Expense.Domain.Entities;
using MediatR;

namespace Expense.Application.Features.Employees.Queries.Get;

public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeResponseDto>
{
	private readonly IUnitOfWork _unitOfWork;

	public GetEmployeeByIdQueryHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<EmployeeResponseDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
	{
		var employee = await _unitOfWork.Repository<Employee>().GetByIdAsync(request.Id);

		if (employee == null)
			throw new KeyNotFoundException("Çalışan bulunamadı.");

		return EmployeeConverters.EmployeeConverter(employee);
	}
}