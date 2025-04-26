using Base.Application.Common.Helpers;
using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using MediatR;
using Papara.Domain.Entities.HR;

namespace Papara.Application.Features.HR.EmployeeAddresses.Commands.Delete;

public class DeleteEmployeeAddressCommandHandler : IRequestHandler<DeleteEmployeeAddressCommand, Unit>

{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserContextService _userContextService;

	public DeleteEmployeeAddressCommandHandler(IUnitOfWork unitOfWork, IUserContextService userContextService)
	{
		_unitOfWork = unitOfWork;
		_userContextService = userContextService;
	}

	public async Task<Unit> Handle(DeleteEmployeeAddressCommand request, CancellationToken cancellationToken)
	{
		var entity = await _unitOfWork.Repository<EmployeeAddress>().GetByIdAsync(request.Id);

		if (entity == null)
			throw new KeyNotFoundException("Adres bulunamadı.");

		var currentUserRole = _userContextService.GetCurrentUserRole();

		if (currentUserRole == "Employee")
		{
			AuthorizationHelper.EnsureEmployeeOwnsData(_userContextService, entity.EmployeeId);
		}

		_unitOfWork.Repository<EmployeeAddress>().Delete(entity);
		await _unitOfWork.CommitAsync();

		return Unit.Value;
	}
}