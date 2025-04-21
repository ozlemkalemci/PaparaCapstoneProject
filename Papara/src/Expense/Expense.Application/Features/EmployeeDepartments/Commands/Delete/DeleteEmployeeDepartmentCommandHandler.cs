using Base.Domain.Interfaces;
using Expense.Domain.Entities;
using MediatR;

namespace Expense.Application.Features.EmployeeDepartments.Commands.Delete;

public class DeleteEmployeeDepartmentCommandHandler : IRequestHandler<DeleteEmployeeDepartmentCommand, Unit>

{
	private readonly IUnitOfWork _unitOfWork;

	public DeleteEmployeeDepartmentCommandHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<Unit> Handle(DeleteEmployeeDepartmentCommand request, CancellationToken cancellationToken)
	{
		var entity = await _unitOfWork.Repository<EmployeeDepartment>().GetByIdAsync(request.Id);

		if (entity == null)
			throw new KeyNotFoundException("Departman bulunamadı.");

		_unitOfWork.Repository<EmployeeDepartment>().Delete(entity);
		await _unitOfWork.CommitAsync();

		return Unit.Value;
	}
}