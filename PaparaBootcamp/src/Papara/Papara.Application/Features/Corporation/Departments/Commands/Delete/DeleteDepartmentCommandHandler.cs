using Base.Domain.Interfaces;
using MediatR;
using Papara.Domain.Entities.Corporation;

namespace Papara.Application.Features.Corporation.Departments.Commands.Delete;

public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, Unit>

{
	private readonly IUnitOfWork _unitOfWork;

	public DeleteDepartmentCommandHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<Unit> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
	{
		var entity = await _unitOfWork.Repository<Department>().GetByIdAsync(request.Id);

		if (entity == null)
			throw new KeyNotFoundException("Departman bulunamadı.");

		_unitOfWork.Repository<Department>().Delete(entity);
		await _unitOfWork.CommitAsync();

		return Unit.Value;
	}
}