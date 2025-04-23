using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using Expense.Application.Features.EmployeeAddresses.Converters;
using Expense.Application.Features.EmployeeAddresses.Models;
using Expense.Domain.Entities;
using MediatR;

namespace Expense.Application.Features.EmployeeAddresses.Commands.Update;

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

		var currentUserId = _userContextService.GetCurrentUserId();
		var currentUserRole = _userContextService.GetCurrentUserRole();

		if (currentUserRole == "Employee" && entity.EmployeeId != currentUserId)
			throw new UnauthorizedAccessException("Bu adrese erişiminiz yok.");

		var dto = request.Request;

		entity.City = dto.City;
		entity.Detail = dto.Detail;
		entity.District = dto.District;

		_unitOfWork.Repository<EmployeeAddress>().Update(entity);
		await _unitOfWork.CommitAsync();

		return EmployeeAddressConverters.EmployeeAddressConverter(entity);
	}
}