using Base.Domain.Interfaces;
using Expense.Domain.Entities;
using MediatR;

namespace Expense.Application.Features.Employees.Commands.Delete;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Unit>

{
	private readonly IUnitOfWork _unitOfWork;

	public DeleteEmployeeCommandHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
	{
		var entity = await _unitOfWork.Repository<Employee>().GetByIdAsync(request.Id);

		if (entity == null)
			throw new KeyNotFoundException("Çalışan bulunamadı.");

		_unitOfWork.Repository<Employee>().Delete(entity);
		await _unitOfWork.CommitAsync();

		return Unit.Value;
	}
}