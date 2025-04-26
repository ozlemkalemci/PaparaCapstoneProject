using Base.Application.Common.Helpers;
using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.HR.EmployeeAddresses.Converters;
using Papara.Application.Features.HR.EmployeeAddresses.Models;
using Papara.Domain.Entities.HR;

namespace Papara.Application.Features.HR.EmployeeAddresses.Commands.Update;

public class UpdateEmployeeAddressCommandHandler : IRequestHandler<UpdateEmployeeAddressCommand, EmployeeAddressResponse>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserContextService _userContextService;

	public UpdateEmployeeAddressCommandHandler(IUnitOfWork unitOfWork, IUserContextService userContextService)
	{
		_unitOfWork = unitOfWork;
		_userContextService = userContextService;
	}

	public async Task<EmployeeAddressResponse> Handle(UpdateEmployeeAddressCommand request, CancellationToken cancellationToken)
	{
		var entity = await _unitOfWork.Repository<EmployeeAddress>().GetByIdAsync(request.Id);
		if (entity == null)
			throw new KeyNotFoundException("Adres bulunamadı.");

		var currentUserRole = _userContextService.GetCurrentUserRole();

		if (currentUserRole == "Employee")
		{
			AuthorizationHelper.EnsureEmployeeOwnsData(_userContextService, entity.EmployeeId);
		}

		var dto = request.Request;

		entity.City = dto.City;
		entity.Detail = dto.Detail;
		entity.District = dto.District;

		_unitOfWork.Repository<EmployeeAddress>().Update(entity);
		await _unitOfWork.CommitAsync();

		return EmployeeAddressConverters.EmployeeAddressConverter(entity);
	}
}