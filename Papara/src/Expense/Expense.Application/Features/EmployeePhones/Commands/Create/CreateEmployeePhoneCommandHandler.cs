using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using Expense.Application.Features.EmployeePhones.Converters;
using Expense.Application.Features.EmployeePhones.Models;
using Expense.Domain.Entities;
using MediatR;

namespace Expense.Application.Features.EmployeePhones.Commands.Create;

public class CreateEmployeePhoneCommandHandler : IRequestHandler<CreateEmployeePhoneCommand, EmployeePhoneResponse>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserContextService _userContextService;

	public CreateEmployeePhoneCommandHandler(IUnitOfWork unitOfWork, IUserContextService userContextService)
	{
		_unitOfWork = unitOfWork;
		_userContextService = userContextService;
	}

	public async Task<EmployeePhoneResponse> Handle(CreateEmployeePhoneCommand request, CancellationToken cancellationToken)
	{
		var dto = request.Request;

		var entity = new EmployeePhone
		{
			PhoneNumber = dto.PhoneNumber,
			EmployeeId = dto.EmployeeId,
			IsPrimary = dto.IsPrimary,
			CreatedDate = DateTimeOffset.UtcNow,
			CreatedById = _userContextService.GetCurrentUserId() ?? 0,
			IsActive = true,
			Type = dto.Type,
		};

		await _unitOfWork.Repository<EmployeePhone>().AddAsync(entity);
		await _unitOfWork.CommitAsync();

		return EmployeePhoneConverters.EmployeePhoneConverter(entity);
	}
}