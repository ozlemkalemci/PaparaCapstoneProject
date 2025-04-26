using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.Finance.ExpenseTypes.Converters;
using Papara.Application.Features.Finance.ExpenseTypes.Models;
using Papara.Domain.Entities.Finance;

namespace Papara.Application.Features.Finance.ExpenseTypes.Commands.Update;

public class UpdateExpenseTypeCommandHandler : IRequestHandler<UpdateExpenseTypeCommand, ExpenseTypeResponse>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserContextService _userContextService;

	public UpdateExpenseTypeCommandHandler(IUnitOfWork unitOfWork, IUserContextService userContextService)
	{
		_unitOfWork = unitOfWork;
		_userContextService = userContextService;
	}

	public async Task<ExpenseTypeResponse> Handle(UpdateExpenseTypeCommand request, CancellationToken cancellationToken)
	{
		var entity = await _unitOfWork.Repository<ExpenseType>().GetByIdAsync(request.Id);
		if (entity == null)
			throw new KeyNotFoundException("Masraf kategorisi bulunamadı.");

		entity.Name = request.Request.Name;
		entity.Description = request.Request.Description;
		entity.UpdatedDate = DateTimeOffset.UtcNow;
		entity.UpdatedById = _userContextService.GetCurrentUserId();

		_unitOfWork.Repository<ExpenseType>().Update(entity);
		await _unitOfWork.CommitAsync();

		return ExpenseTypeConverters.ExpenseTypeConverter(entity);
	}
}
