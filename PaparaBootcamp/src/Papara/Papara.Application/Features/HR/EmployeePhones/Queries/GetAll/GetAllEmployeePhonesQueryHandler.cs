using Base.Application.Common.Extensions;
using Base.Domain.Interfaces;
using MediatR;
using System.Linq.Expressions;
using Papara.Application.Features.HR.EmployeePhones.Converters;
using Papara.Application.Features.HR.EmployeePhones.Models;
using Papara.Domain.Entities.HR;

namespace Papara.Application.Features.HR.EmployeePhones.Queries.GetAll;

public class GetAllEmployeePhonesQueryHandler : IRequestHandler<GetAllEmployeePhonesQuery, List<EmployeePhoneResponse>>
{
	private readonly IUnitOfWork _unitOfWork;

	public GetAllEmployeePhonesQueryHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<List<EmployeePhoneResponse>> Handle(GetAllEmployeePhonesQuery request, CancellationToken cancellationToken)
	{
		var filter = (Expression<Func<EmployeePhone, bool>>)(x => x.IsActive);
		var includes = new List<Expression<Func<EmployeePhone, object>>>();

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