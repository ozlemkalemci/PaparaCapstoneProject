using Base.Application.Common.Extensions;
using Base.Domain.Interfaces;
using MediatR;
using System.Linq.Expressions;
using Papara.Application.Features.HR.EmployeeAddresses.Converters;
using Papara.Application.Features.HR.EmployeeAddresses.Models;
using Papara.Domain.Entities.HR;
using Base.Domain.Enums;
using Base.Application.Interfaces;
using Base.Application.Common.Helpers;

namespace Papara.Application.Features.HR.EmployeeAddresses.Queries.GetAll;

public class GetAllEmployeeAddressesQueryHandler : IRequestHandler<GetAllEmployeeAddressesQuery, List<EmployeeAddressResponse>>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserContextService _userContextService;

	public GetAllEmployeeAddressesQueryHandler(IUnitOfWork unitOfWork, IUserContextService userContextService)
	{
		_unitOfWork = unitOfWork;
		_userContextService = userContextService;
	}
	public async Task<List<EmployeeAddressResponse>> Handle(GetAllEmployeeAddressesQuery request, CancellationToken cancellationToken)
	{
		var filter = (Expression<Func<EmployeeAddress, bool>>)(x => x.IsActive);
		var includes = new List<Expression<Func<EmployeeAddress, object>>>();
		var currentUserRole = _userContextService.GetCurrentUserRole();
		if ((request.Request.EmployeeId == null || request.Request.EmployeeId == 0) && currentUserRole == "Employee")
		{
			filter = filter.And(x => x.EmployeeId == _userContextService.GetCurrentEmployeeId());
		}
		if (request.Request.EmployeeId > 0 && currentUserRole == "Employee")
		{
			AuthorizationHelper.EnsureEmployeeOwnsData(_userContextService, request.Request.EmployeeId);
		}
		if (request.Request.EmployeeId > 0)
		{
			filter = filter.And(x => x.EmployeeId == request.Request.EmployeeId);
		}

		if (request.Request.IncludeEmployee)
		{
			includes.Add(x => x.Employee);
		}

		var EmployeeAddresses = await _unitOfWork.Repository<EmployeeAddress>()
			.GetAllAsync(filter, includes.ToArray());

		return EmployeeAddressConverters.EmployeeAddressConverterList(EmployeeAddresses);
	}
}