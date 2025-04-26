using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.HR.EmployeePhones.Converters;
using Papara.Application.Features.HR.EmployeePhones.Models;
using Papara.Domain.Entities.HR;

namespace Papara.Application.Features.HR.EmployeePhones.Queries.Get;

public class GetEmployeePhoneByIdQueryHandler : IRequestHandler<GetEmployeePhoneByIdQuery, EmployeePhoneResponse>
{
	private readonly IUnitOfWork _unitOfWork;

	public GetEmployeePhoneByIdQueryHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<EmployeePhoneResponse> Handle(GetEmployeePhoneByIdQuery request, CancellationToken cancellationToken)
	{
		var EmployeePhone = await _unitOfWork.Repository<EmployeePhone>().GetByIdAsync(request.Id);

		if (EmployeePhone == null)
			throw new KeyNotFoundException("Telefon bulunamadı.");

		return EmployeePhoneConverters.EmployeePhoneConverter(EmployeePhone);
	}
}