using Base.Application.Common.Helpers;
using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using MediatR;
using Papara.Domain.Entities.HR;

namespace Papara.Application.Features.HR.EmployeePhones.Commands.Delete;

public class DeleteEmployeePhoneCommandHandler : IRequestHandler<DeleteEmployeePhoneCommand, Unit>

{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserContextService _userContextService;
	public DeleteEmployeePhoneCommandHandler(IUnitOfWork unitOfWork, IUserContextService userContextService)
	{
		_unitOfWork = unitOfWork;
		_userContextService = userContextService;
	}

	public async Task<Unit> Handle(DeleteEmployeePhoneCommand request, CancellationToken cancellationToken)
	{
		var entity = await _unitOfWork.Repository<EmployeePhone>().GetByIdAsync(request.Id);

		if (entity == null)
			throw new KeyNotFoundException("Telefon bulunamadı.");

		var currentUserRole = _userContextService.GetCurrentUserRole();

		if (currentUserRole == "Employee")
		{
			AuthorizationHelper.EnsureEmployeeOwnsData(_userContextService, entity.EmployeeId);
		}

		_unitOfWork.Repository<EmployeePhone>().Delete(entity);
		await _unitOfWork.CommitAsync();

		return Unit.Value;

	}
}