using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using Expense.Application.Features.Employees.Converters;
using Expense.Application.Features.Employees.Models;
using Expense.Domain.Entities;
using MediatR;

namespace Expense.Application.Features.Employees.Commands.Update;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeResponse>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserContextService _userContextService;

	public UpdateEmployeeCommandHandler(IUnitOfWork unitOfWork, IUserContextService userContextService)
	{
		_unitOfWork = unitOfWork;
		_userContextService = userContextService;
	}

	public async Task<EmployeeResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
	{
		var entity = await _unitOfWork.Repository<Employee>().GetByIdAsync(request.Id);
		if (entity == null)
			throw new KeyNotFoundException("Çalışan bulunamadı.");

		var dto = request.Request;

		entity.Email = dto.Email;
		entity.DepartmentId = dto.DepartmentId;
		entity.UserId = dto.UserId;

		_unitOfWork.Repository<Employee>().Update(entity);
		await _unitOfWork.CommitAsync();

		return EmployeeConverters.EmployeeConverter(entity);
	}
}