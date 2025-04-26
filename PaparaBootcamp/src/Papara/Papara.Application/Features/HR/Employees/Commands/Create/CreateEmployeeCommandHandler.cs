using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.HR.Employees.Converters;
using Papara.Application.Features.HR.Employees.Models;
using Papara.Domain.Entities.HR;

namespace Papara.Application.Features.HR.Employees.Commands.Create;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeResponse>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserContextService _userContextService;

	public CreateEmployeeCommandHandler(IUnitOfWork unitOfWork, IUserContextService userContextService)
	{
		_unitOfWork = unitOfWork;
		_userContextService = userContextService;
	}

	public async Task<EmployeeResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
	{
		var dto = request.Request;

		var activeEmployeeExists = await _unitOfWork.Repository<Employee>().AnyAsync(e => e.UserId == dto.UserId && e.IsActive);

		if (activeEmployeeExists)
			throw new InvalidOperationException("Bu kullanıcıya ait zaten aktif bir çalışan mevcut.");

		var entity = new Employee
		{
			Email = dto.Email,
			FirstName = dto.FirstName,
			MiddleName = dto.MiddleName,
			LastName = dto.LastName,
			IdentityNumber = dto.IdentityNumber,
			IBAN = dto.IBAN,
			UserId = dto.UserId,
			DepartmentId = dto.DepartmentId,
			CreatedDate = DateTimeOffset.UtcNow,
			CreatedById = _userContextService.GetCurrentUserId() ?? 0,
			IsActive = true
		};

		await _unitOfWork.Repository<Employee>().AddAsync(entity);
		await _unitOfWork.CommitAsync();

		return EmployeeConverters.EmployeeConverter(entity);
	}
}
