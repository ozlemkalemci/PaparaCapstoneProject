using Base.Application.Common.Extensions;
using Base.Domain.Interfaces;
using MediatR;
using System.Linq.Expressions;
using Papara.Application.Features.HR.EmployeeAddresses.Converters;
using Papara.Application.Features.HR.EmployeeAddresses.Models;
using Papara.Domain.Entities.HR;

namespace Papara.Application.Features.HR.EmployeeAddresses.Queries.GetAll;

public class GetAllEmployeeAddressesQueryHandler : IRequestHandler<GetAllEmployeeAddressesQuery, List<EmployeeAddressResponse>>
{
	private readonly IUnitOfWork _unitOfWork;

	public GetAllEmployeeAddressesQueryHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
	public async Task<List<EmployeeAddressResponse>> Handle(GetAllEmployeeAddressesQuery request, CancellationToken cancellationToken)
	{
		var filter = (Expression<Func<EmployeeAddress, bool>>)(x => x.IsActive);
		var includes = new List<Expression<Func<EmployeeAddress, object>>>();

		if (request.Request.EmployeeId > 0)
		{
			filter = filter.And(x => x.EmployeeId == request.Request.EmployeeId);

		}

		if (request.Request.IncludeEmployee)
		{
			includes.Add(x => x.Employee);
		}

		var EmployeeAddresss = await _unitOfWork.Repository<EmployeeAddress>()
			.GetAllAsync(filter, includes.ToArray());

		return EmployeeAddressConverters.EmployeeAddressConverterList(EmployeeAddresss);
	}
}