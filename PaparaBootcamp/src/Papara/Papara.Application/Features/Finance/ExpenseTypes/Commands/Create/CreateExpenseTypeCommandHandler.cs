using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.Finance.ExpenseTypes.Converters;
using Papara.Application.Features.Finance.ExpenseTypes.Models;
using Papara.Domain.Entities.Finance;

namespace Papara.Application.Features.Finance.ExpenseTypes.Commands.Create;

public class CreateExpenseTypeCommandHandler : IRequestHandler<CreateExpenseTypeCommand, ExpenseTypeResponse>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserContextService _userContextService;

	public CreateExpenseTypeCommandHandler(IUnitOfWork unitOfWork, IUserContextService userContextService)
	{
		_unitOfWork = unitOfWork;
		_userContextService = userContextService;
	}

	public async Task<ExpenseTypeResponse> Handle(CreateExpenseTypeCommand request, CancellationToken cancellationToken)
	{
		var dto = request.Request;

		var entity = new ExpenseType
		{
			Name = dto.Name,
			Description = dto.Description,
			CreatedDate = DateTimeOffset.UtcNow,
			CreatedById = _userContextService.GetCurrentUserId() ?? 0,
			IsActive = true
		};

		await _unitOfWork.Repository<ExpenseType>().AddAsync(entity);
		await _unitOfWork.CommitAsync();

		return ExpenseTypeConverters.ExpenseTypeConverter(entity);
	}
}
