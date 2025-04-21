using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using Expense.Application.Features.EmployeeDepartments.Converters;
using Expense.Application.Features.EmployeeDepartments.Models;
using Expense.Domain.Entities;
using MediatR;

namespace Expense.Application.Features.EmployeeDepartments.Commands.Create;


public class CreateEmployeeDepartmentCommandHandler : IRequestHandler<CreateEmployeeDepartmentCommand, EmployeeDepartmentResponse>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserContextService _userContextService;

	public CreateEmployeeDepartmentCommandHandler(IUnitOfWork unitOfWork, IUserContextService userContextService)
	{
		_unitOfWork = unitOfWork;
		_userContextService = userContextService;
	}

	public async Task<EmployeeDepartmentResponse> Handle(CreateEmployeeDepartmentCommand request, CancellationToken cancellationToken)
	{
		var dto = request.Request;

		var entity = new EmployeeDepartment
		{
			DepartmentName = dto.DepartmentName,
			CreatedDate = DateTimeOffset.UtcNow,
			CreatedById = _userContextService.GetCurrentUserId() ?? 0,
			IsActive = true
		};

		await _unitOfWork.Repository<EmployeeDepartment>().AddAsync(entity);
		await _unitOfWork.CommitAsync();

		return EmployeeDepartmentConverters.EmployeeDepartmentConverter(entity);
	}
}