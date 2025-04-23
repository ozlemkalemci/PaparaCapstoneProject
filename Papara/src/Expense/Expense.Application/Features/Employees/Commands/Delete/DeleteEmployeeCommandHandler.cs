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

		using var transaction = _unitOfWork.BeginTransaction();

		try
		{
			var phones = await _unitOfWork.Repository<EmployeePhone>()
				.Where(p => p.EmployeeId == entity.Id && p.IsActive);

			foreach (var phone in phones)
				_unitOfWork.Repository<EmployeePhone>().Delete(phone);

			var addresses = await _unitOfWork.Repository<EmployeeAddress>()
				.Where(p => p.EmployeeId == entity.Id && p.IsActive);

			foreach (var address in addresses)
				_unitOfWork.Repository<EmployeeAddress>().Delete(address);

			_unitOfWork.Repository<Employee>().Delete(entity);

			await _unitOfWork.CommitAsync();
			await transaction.CommitAsync();

			return Unit.Value;
		}
		catch (Exception)
		{
			await transaction.RollbackAsync();
			throw;
		}
	}
}