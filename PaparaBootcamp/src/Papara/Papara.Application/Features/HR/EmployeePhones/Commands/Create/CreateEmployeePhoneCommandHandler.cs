using Base.Application.Common.Helpers;
using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.HR.EmployeePhones.Converters;
using Papara.Application.Features.HR.EmployeePhones.Models;
using Papara.Domain.Entities.HR;

namespace Papara.Application.Features.HR.EmployeePhones.Commands.Create;

public class CreateEmployeePhoneCommandHandler : IRequestHandler<CreateEmployeePhoneCommand, EmployeePhoneResponse>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserContextService _userContextService;

	public CreateEmployeePhoneCommandHandler(IUnitOfWork unitOfWork, IUserContextService userContextService)
	{
		_unitOfWork = unitOfWork;
		_userContextService = userContextService;
	}

	public async Task<EmployeePhoneResponse> Handle(CreateEmployeePhoneCommand request, CancellationToken cancellationToken)
	{
		var dto = request.Request;
		var currentUserRole = _userContextService.GetCurrentUserRole();

		if (currentUserRole == "Employee")
		{
			AuthorizationHelper.EnsureEmployeeOwnsData(_userContextService, dto.EmployeeId);
		}
		var entity = new EmployeePhone
		{
			PhoneNumber = dto.PhoneNumber,
			EmployeeId = dto.EmployeeId,
			IsPrimary = dto.IsPrimary,
			CreatedDate = DateTimeOffset.UtcNow,
			CreatedById = _userContextService.GetCurrentUserId() ?? 0,
			IsActive = true,
			Type = dto.Type,
		};

		await _unitOfWork.Repository<EmployeePhone>().AddAsync(entity);
		await _unitOfWork.CommitAsync();

		return EmployeePhoneConverters.EmployeePhoneConverter(entity);
	}
}