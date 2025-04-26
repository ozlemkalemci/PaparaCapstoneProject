using Base.Application.Common.Helpers;
using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.HR.EmployeePhones.Converters;
using Papara.Application.Features.HR.EmployeePhones.Models;
using Papara.Domain.Entities.HR;

namespace Papara.Application.Features.HR.EmployeePhones.Queries.Get;

public class GetEmployeePhoneByIdQueryHandler : IRequestHandler<GetEmployeePhoneByIdQuery, EmployeePhoneResponse>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserContextService _userContextService;
	public GetEmployeePhoneByIdQueryHandler(
		IUnitOfWork unitOfWork,
		IUserContextService userContextService)
	{
		_unitOfWork = unitOfWork;
		_userContextService = userContextService;
	}

	public async Task<EmployeePhoneResponse> Handle(GetEmployeePhoneByIdQuery request, CancellationToken cancellationToken)
	{
		var entity = await _unitOfWork.Repository<EmployeePhone>().GetByIdAsync(request.Id);

		if (entity == null)
			throw new KeyNotFoundException("Telefon bulunamadı.");
		var currentUserRole = _userContextService.GetCurrentUserRole();

		if (currentUserRole == "Employee")
		{
			AuthorizationHelper.EnsureEmployeeOwnsData(_userContextService, entity.EmployeeId);
		}
		return EmployeePhoneConverters.EmployeePhoneConverter(entity);
	}
}