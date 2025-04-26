using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.Corporation.Departments.Converters;
using Papara.Application.Features.Corporation.Departments.Models;
using Papara.Domain.Entities.Corporation;

namespace Papara.Application.Features.Corporation.Departments.Commands.Update;

public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, DepartmentResponse>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserContextService _userContextService;

	public UpdateDepartmentCommandHandler(IUnitOfWork unitOfWork, IUserContextService userContextService)
	{
		_unitOfWork = unitOfWork;
		_userContextService = userContextService;
	}

	public async Task<DepartmentResponse> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
	{
		var entity = await _unitOfWork.Repository<Department>().GetByIdAsync(request.Id);
		if (entity == null)
			throw new KeyNotFoundException("Departman bulunamadı.");

		var dto = request.Request;

		entity.DepartmentName = dto.DepartmentName;

		_unitOfWork.Repository<Department>().Update(entity);
		await _unitOfWork.CommitAsync();

		return DepartmentConverters.DepartmentConverter(entity);
	}
}