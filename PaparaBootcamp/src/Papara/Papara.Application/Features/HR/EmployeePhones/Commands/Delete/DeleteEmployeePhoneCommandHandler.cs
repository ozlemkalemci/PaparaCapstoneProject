using Base.Domain.Interfaces;
using MediatR;
using Papara.Domain.Entities.HR;

namespace Papara.Application.Features.HR.EmployeePhones.Commands.Delete;

public class DeleteEmployeePhoneCommandHandler : IRequestHandler<DeleteEmployeePhoneCommand, Unit>

{
	private readonly IUnitOfWork _unitOfWork;

	public DeleteEmployeePhoneCommandHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<Unit> Handle(DeleteEmployeePhoneCommand request, CancellationToken cancellationToken)
	{
		var entity = await _unitOfWork.Repository<EmployeePhone>().GetByIdAsync(request.Id);

		if (entity == null)
			throw new KeyNotFoundException("Telefon bulunamadı.");

		_unitOfWork.Repository<EmployeePhone>().Delete(entity);
		await _unitOfWork.CommitAsync();

		return Unit.Value;

	}
}