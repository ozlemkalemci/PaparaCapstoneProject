using Base.Application.Common.Helpers;
using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.Finance.Expenses.Converters;
using Papara.Application.Features.Finance.Expenses.Models;
using Papara.Domain.Entities.Finance;

namespace Papara.Application.Features.Finance.Expenses.Commands.Update;

public class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommand, ExpenseResponse>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserContextService _userContextService;

	public UpdateExpenseCommandHandler(IUnitOfWork unitOfWork, IUserContextService userContextService)
	{
		_unitOfWork = unitOfWork;
		_userContextService = userContextService;
	}

	public async Task<ExpenseResponse> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
	{
		var entity = await _unitOfWork.Repository<Expense>()
			.GetByIdAsync(request.Id, x => x.Approvals);

		if (entity == null)
			throw new KeyNotFoundException("Masraf kaydı bulunamadı.");

		// Masrafın aktif bir approval'ı var mı
		var activeApproval = entity.Approvals?.FirstOrDefault(x => x.IsActive);

		if (activeApproval == null)
			throw new InvalidOperationException("Bu masraf için geçerli bir onay kaydı bulunamadı.");

		// Sadece Bekliyor (Pending) statüsünde olanlar güncellenebilir
		if (activeApproval.Status != Domain.Enums.Finance.ExpenseApprovalStatus.Pending)
			throw new InvalidOperationException("Sadece beklemede olan masraf kayıtları güncellenebilir.");
		
		var currentUserRole = _userContextService.GetCurrentUserRole();

		if (currentUserRole == "Employee")
		{
			AuthorizationHelper.EnsureEmployeeOwnsData(_userContextService, entity.EmployeeId);
		}

		var dto = request.Request;

		entity.Amount = dto.Amount;
		entity.Description = dto.Description;
		entity.ExpenseDate = dto.ExpenseDate;
		entity.Concluded = dto.Concluded;
		entity.ExpenseTypeId = dto.ExpenseTypeId;

		_unitOfWork.Repository<Expense>().Update(entity);
		await _unitOfWork.CommitAsync();

		return ExpenseConverters.ExpenseConverter(entity);
	}
}
