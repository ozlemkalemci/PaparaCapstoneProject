using Base.Domain.Interfaces;
using Expense.Application.Features.EmployeeAddresses.Converters;
using Expense.Application.Features.EmployeeAddresses.Models;
using Expense.Domain.Entities;
using MediatR;

namespace Expense.Application.Features.EmployeeAddresses.Queries.Get;

public class GetEmployeeAddressByIdQueryHandler : IRequestHandler<GetEmployeeAddressByIdQuery, EmployeeAddressResponse>
{
	private readonly IUnitOfWork _unitOfWork;

	public GetEmployeeAddressByIdQueryHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<EmployeeAddressResponse> Handle(GetEmployeeAddressByIdQuery request, CancellationToken cancellationToken)
	{
		var EmployeeAddress = await _unitOfWork.Repository<EmployeeAddress>().GetByIdAsync(request.Id);

		if (EmployeeAddress == null)
			throw new KeyNotFoundException("Adres bulunamadı.");

		return EmployeeAddressConverters.EmployeeAddressConverter(EmployeeAddress);
	}
}