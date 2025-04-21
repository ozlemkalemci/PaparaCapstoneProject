using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using Expense.Application.Features.EmployeeDepartments.Converters;
using Expense.Application.Features.EmployeeDepartments.Models;
using Expense.Domain.Entities;
using MediatR;

namespace Expense.Application.Features.EmployeeDepartments.Commands.Update;

public class UpdateEmployeeDepartmentCommandHandler : IRequestHandler<UpdateEmployeeDepartmentCommand, EmployeeDepartmentResponse>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserContextService _userContextService;

	public UpdateEmployeeDepartmentCommandHandler(IUnitOfWork unitOfWork, IUserContextService userContextService)
	{
		_unitOfWork = unitOfWork;
		_userContextService = userContextService;
	}

	public async Task<EmployeeDepartmentResponse> Handle(UpdateEmployeeDepartmentCommand request, CancellationToken cancellationToken)
	{
		var entity = await _unitOfWork.Repository<EmployeeDepartment>().GetByIdAsync(request.Id);
		if (entity == null)
			throw new KeyNotFoundException("Departman bulunamadı.");

		var dto = request.Request;

		entity.DepartmentName = dto.DepartmentName;

		_unitOfWork.Repository<EmployeeDepartment>().Update(entity);
		await _unitOfWork.CommitAsync();

		return EmployeeDepartmentConverters.EmployeeDepartmentConverter(entity);
	}
}