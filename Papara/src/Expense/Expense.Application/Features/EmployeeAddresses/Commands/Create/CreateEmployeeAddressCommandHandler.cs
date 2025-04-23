using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using Expense.Application.Features.EmployeeAddresses.Converters;
using Expense.Application.Features.EmployeeAddresses.Models;
using Expense.Domain.Entities;
using MediatR;

namespace Expense.Application.Features.EmployeeAddresses.Commands.Create;

public class CreateEmployeeAddressCommandHandler : IRequestHandler<CreateEmployeeAddressCommand, EmployeeAddressResponse>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserContextService _userContextService;

	public CreateEmployeeAddressCommandHandler(IUnitOfWork unitOfWork, IUserContextService userContextService)
	{
		_unitOfWork = unitOfWork;
		_userContextService = userContextService;
	}

	public async Task<EmployeeAddressResponse> Handle(CreateEmployeeAddressCommand request, CancellationToken cancellationToken)
	{
		var dto = request.Request;

		var entity = new EmployeeAddress
		{
			Detail = dto.Detail,
			District = dto.District,
			City = dto.City,
			EmployeeId = dto.EmployeeId,
			CreatedDate = DateTimeOffset.UtcNow,
			CreatedById = _userContextService.GetCurrentUserId() ?? 0,
			IsActive = true,
		};

		await _unitOfWork.Repository<EmployeeAddress>().AddAsync(entity);
		await _unitOfWork.CommitAsync();

		return EmployeeAddressConverters.EmployeeAddressConverter(entity);
	}
}