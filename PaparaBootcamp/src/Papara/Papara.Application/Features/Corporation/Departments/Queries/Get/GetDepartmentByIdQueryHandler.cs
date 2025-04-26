using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.Corporation.Departments.Converters;
using Papara.Application.Features.Corporation.Departments.Models;
using Papara.Domain.Entities.Corporation;

namespace Papara.Application.Features.Corporation.Departments.Queries.Get;

public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, DepartmentResponse>
{
	private readonly IUnitOfWork _unitOfWork;

	public GetDepartmentByIdQueryHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<DepartmentResponse> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
	{
		var Department = await _unitOfWork.Repository<Department>().GetByIdAsync(request.Id);

		if (Department == null)
			throw new KeyNotFoundException("Departman bulunamadı.");

		return DepartmentConverters.DepartmentConverter(Department);
	}
}