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
		var employee = await _unitOfWork.Repository<Employee>().GetByIdAsync(request.Id);

		if (employee == null)
			throw new KeyNotFoundException("Çalışan bulunamadı.");

		var currentUserId = _userContextService.GetCurrentUserId();
		var currentUserRole = _userContextService.GetCurrentUserRole();

		// Eğer employee ise sadece kendi kaydına erişebilir
		if (currentUserRole == "Employee" && employee.Id != currentUserId)
			throw new UnauthorizedAccessException("Sadece kendi bilgilerinizi görüntüleyebilirsiniz.");

		return EmployeeConverters.EmployeeConverter(employee);
	}
}
