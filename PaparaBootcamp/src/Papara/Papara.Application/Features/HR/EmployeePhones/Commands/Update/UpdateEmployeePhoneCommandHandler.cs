using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.HR.EmployeePhones.Converters;
using Papara.Application.Features.HR.EmployeePhones.Models;
using Papara.Domain.Entities.HR;

namespace Papara.Application.Features.HR.EmployeePhones.Commands.Update;

public class UpdateEmployeePhoneCommandHandler : IRequestHandler<UpdateEmployeePhoneCommand, EmployeePhoneResponse>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserContextService _userContextService;

	public UpdateEmployeePhoneCommandHandler(IUnitOfWork unitOfWork, IUserContextService userContextService)
	{
		_unitOfWork = unitOfWork;
		_userContextService = userContextService;
	}

	public async Task<EmployeePhoneResponse> Handle(UpdateEmployeePhoneCommand request, CancellationToken cancellationToken)
	{
		var entity = await _unitOfWork.Repository<EmployeePhone>().GetByIdAsync(request.Id);
		if (entity == null)
			throw new KeyNotFoundException("Telefon bulunamadı.");

		var dto = request.Request;

		entity.PhoneNumber = dto.PhoneNumber;
		entity.IsPrimary = dto.IsPrimary;

		_unitOfWork.Repository<EmployeePhone>().Update(entity);
		await _unitOfWork.CommitAsync();

		return EmployeePhoneConverters.EmployeePhoneConverter(entity);
	}
}