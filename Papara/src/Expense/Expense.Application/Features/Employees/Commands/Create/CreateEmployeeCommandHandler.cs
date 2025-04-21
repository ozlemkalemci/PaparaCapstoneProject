using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using Expense.Application.Features.Employees.Commands.Create;
using Expense.Application.Features.Employees.Converters;
using Expense.Application.Features.Employees.Models;
using Expense.Domain.Entities;
using MediatR;

namespace Expense.Application.Features.Employees.Handlers;

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
