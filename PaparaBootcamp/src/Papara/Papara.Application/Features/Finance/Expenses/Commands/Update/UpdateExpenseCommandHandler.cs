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
		var expense = await _unitOfWork.Repository<Expense>()
			.GetByIdAsync(request.Id, x => x.Approvals);

		if (expense == null)
			throw new KeyNotFoundException("Masraf kaydı bulunamadı.");

		var currentUserId = _userContextService.GetCurrentUserId();
		var currentUserRole = _userContextService.GetCurrentUserRole();

		if (currentUserRole == "Employee" && expense.EmployeeId != currentUserId)
			throw new UnauthorizedAccessException("Başka bir çalışanın masraf kaydını güncelleyemezsiniz.");

		// Masrafın aktif bir approval'ı var mı
		var activeApproval = expense.Approvals?.FirstOrDefault(x => x.IsActive);

		if (activeApproval == null)
			throw new InvalidOperationException("Bu masraf için geçerli bir onay kaydı bulunamadı.");

		// Sadece Bekliyor (Pending) statüsünde olanlar güncellenebilir
		if (activeApproval.Status != Domain.Enums.Finance.ExpenseApprovalStatus.Pending)
			throw new InvalidOperationException("Sadece beklemede olan masraf kayıtları güncellenebilir.");

		var dto = request.Request;

		expense.Amount = dto.Amount;
		expense.Description = dto.Description;
		expense.ExpenseDate = dto.ExpenseDate;
		expense.ExpenseTypeId = dto.ExpenseTypeId;

		_unitOfWork.Repository<Expense>().Update(expense);
		await _unitOfWork.CommitAsync();

		return ExpenseConverters.ExpenseConverter(expense);
	}
}
