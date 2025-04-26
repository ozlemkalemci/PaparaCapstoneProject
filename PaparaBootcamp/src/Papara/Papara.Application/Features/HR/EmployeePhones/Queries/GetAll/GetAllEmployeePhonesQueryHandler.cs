using Base.Application.Common.Extensions;
using Base.Application.Common.Helpers;
using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.HR.EmployeePhones.Converters;
using Papara.Application.Features.HR.EmployeePhones.Models;
using Papara.Domain.Entities.HR;
using System.Linq.Expressions;

namespace Papara.Application.Features.HR.EmployeePhones.Queries.GetAll;

public class GetAllEmployeePhonesQueryHandler : IRequestHandler<GetAllEmployeePhonesQuery, List<EmployeePhoneResponse>>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserContextService _userContextService;
	public GetAllEmployeePhonesQueryHandler(IUnitOfWork unitOfWork, IUserContextService userContextService)
	{
		_unitOfWork = unitOfWork;
		_userContextService = userContextService;
	}

	public async Task<List<EmployeePhoneResponse>> Handle(GetAllEmployeePhonesQuery request, CancellationToken cancellationToken)
	{
		var filter = (Expression<Func<EmployeePhone, bool>>)(x => x.IsActive);
		var includes = new List<Expression<Func<EmployeePhone, object>>>();

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

		var EmployeePhones = await _unitOfWork.Repository<EmployeePhone>()
			.GetAllAsync(filter, includes.ToArray());

		return EmployeePhoneConverters.EmployeePhoneConverterList(EmployeePhones);
	}
}