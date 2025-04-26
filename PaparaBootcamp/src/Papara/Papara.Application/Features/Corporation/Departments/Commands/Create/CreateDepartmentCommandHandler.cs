using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.Corporation.Departments.Converters;
using Papara.Application.Features.Corporation.Departments.Models;
using Papara.Domain.Entities.Corporation;

namespace Papara.Application.Features.Corporation.Departments.Commands.Create;


public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, DepartmentResponse>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserContextService _userContextService;

	public CreateDepartmentCommandHandler(IUnitOfWork unitOfWork, IUserContextService userContextService)
	{
		_unitOfWork = unitOfWork;
		_userContextService = userContextService;
	}

	public async Task<DepartmentResponse> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
	{
		var dto = request.Request;

		var entity = new Department
		{
			DepartmentName = dto.DepartmentName,
			CreatedDate = DateTimeOffset.UtcNow,
			CreatedById = _userContextService.GetCurrentUserId() ?? 0,
			IsActive = true
		};

		await _unitOfWork.Repository<Department>().AddAsync(entity);
		await _unitOfWork.CommitAsync();

		return DepartmentConverters.DepartmentConverter(entity);
	}
}