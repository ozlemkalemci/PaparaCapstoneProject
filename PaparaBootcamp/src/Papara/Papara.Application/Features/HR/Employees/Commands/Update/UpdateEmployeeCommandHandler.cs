using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.HR.Employees.Converters;
using Papara.Application.Features.HR.Employees.Models;
using Papara.Domain.Entities.HR;

namespace Papara.Application.Features.HR.Employees.Commands.Update;

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

		entity.DepartmentId = dto.DepartmentId;
		entity.UserId = dto.UserId;

		_unitOfWork.Repository<Employee>().Update(entity);
		await _unitOfWork.CommitAsync();

		return EmployeeConverters.EmployeeConverter(entity);
	}
}