using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.HR.Employees.Converters;
using Papara.Application.Features.HR.Employees.Models;
using Papara.Domain.Entities.HR;

namespace Papara.Application.Features.HR.Employees.Queries.Get;

public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeResponse>
{
	private readonly IUnitOfWork _unitOfWork;

	public GetEmployeeByIdQueryHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<EmployeeResponse> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
	{
		var employee = await _unitOfWork.Repository<Employee>().GetByIdAsync(request.Id);

		if (employee == null)
			throw new KeyNotFoundException("Çalışan bulunamadı.");

		return EmployeeConverters.EmployeeConverter(employee);
	}
}