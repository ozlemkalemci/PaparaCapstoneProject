using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.HR.EmployeeAddresses.Converters;
using Papara.Application.Features.HR.EmployeeAddresses.Models;
using Papara.Domain.Entities.HR;

namespace Papara.Application.Features.HR.EmployeeAddresses.Queries.Get;

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