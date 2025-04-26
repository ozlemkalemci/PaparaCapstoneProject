using Base.Application.Common.Helpers;
using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.HR.Employees.Converters;
using Papara.Application.Features.HR.Employees.Models;
using Papara.Domain.Entities.HR;

namespace Papara.Application.Features.HR.Employees.Queries.Get;

public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeResponse>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserContextService _userContextService;

	public GetEmployeeByIdQueryHandler(IUnitOfWork unitOfWork, IUserContextService userContextService)
	{
		_unitOfWork = unitOfWork;
		_userContextService = userContextService;
	}

	public async Task<EmployeeResponse> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
	{
		var entity = await _unitOfWork.Repository<Employee>().GetByIdAsync(request.Id);

		if (entity == null)
			throw new KeyNotFoundException("Çalışan bulunamadı.");

		var currentUserRole = _userContextService.GetCurrentUserRole();

		if (currentUserRole == "Employee")
		{
			AuthorizationHelper.EnsureEmployeeOwnsData(_userContextService, entity.Id);
		}
		return EmployeeConverters.EmployeeConverter(entity);
	}
}
