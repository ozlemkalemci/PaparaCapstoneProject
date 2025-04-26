using Base.Application.Common.Helpers;
using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.HR.EmployeeAddresses.Converters;
using Papara.Application.Features.HR.EmployeeAddresses.Models;
using Papara.Domain.Entities.HR;

namespace Papara.Application.Features.HR.EmployeeAddresses.Queries.Get;

public class GetEmployeeAddressByIdQueryHandler : IRequestHandler<GetEmployeeAddressByIdQuery, EmployeeAddressResponse>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserContextService _userContextService;
	public GetEmployeeAddressByIdQueryHandler(
		IUnitOfWork unitOfWork, 
		IUserContextService userContextService)
	{
		_unitOfWork = unitOfWork;
		_userContextService = userContextService;
	}

	public async Task<EmployeeAddressResponse> Handle(GetEmployeeAddressByIdQuery request, CancellationToken cancellationToken)
	{
		var entity = await _unitOfWork.Repository<EmployeeAddress>().GetByIdAsync(request.Id);

		if (entity == null)
			throw new KeyNotFoundException("Adres bulunamadı.");

		var currentUserRole = _userContextService.GetCurrentUserRole();

		if (currentUserRole == "Employee")
		{
			AuthorizationHelper.EnsureEmployeeOwnsData(_userContextService, entity.EmployeeId);
		}

		return EmployeeAddressConverters.EmployeeAddressConverter(entity);
	}
}