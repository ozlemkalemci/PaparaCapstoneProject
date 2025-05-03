using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using Papara.Application.Features.Finance.ExpenseApprovals.Converters;
using Papara.Application.Features.Finance.ExpenseApprovals.Models;
using Papara.Application.Services.Approvals;
using Papara.Application.Services.Banking;
using Papara.Application.Services.Banking.Models;
using Papara.Domain.Entities.Corporation;
using Papara.Domain.Entities.Finance;
using Papara.Domain.Enums.Bank;
using Papara.Domain.Enums.Finance;

namespace Papara.Application.Services.Finance.Approvals;

public class ExpenseApprovalService : IExpenseApprovalService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserContextService _userContextService;
	private readonly IBankTransferSimulatorService _bankTransferSimulatorService;

	public ExpenseApprovalService(
		IUnitOfWork unitOfWork,
		IUserContextService userContextService,
		IBankTransferSimulatorService bankTransferSimulatorService)
	{
		_unitOfWork = unitOfWork;
		_userContextService = userContextService;
		_bankTransferSimulatorService = bankTransferSimulatorService;
	}

	public async Task<ExpenseApprovalResponse> CreateAndTransferApprovalAsync(CreateAndTransferApprovalRequest request)
	{
		using var transaction = _unitOfWork.BeginTransaction();

		try
		{
			var existingApprovals = await _unitOfWork.Repository<ExpenseApproval>()
				.Where(x => x.ExpenseId == request.ExpenseId && x.IsActive);

			var activeApproval = existingApprovals.FirstOrDefault();

			if (activeApproval?.Status == ExpenseApprovalStatus.Pending)
			{
				_unitOfWork.Repository<ExpenseApproval>().Delete(activeApproval);
			}
			else if (activeApproval != null)
			{
				throw new InvalidOperationException("Bu masraf zaten sonuçlanmış. Yeni onay yapılamaz.");
			}

			var expense = await _unitOfWork.Repository<Expense>().GetByIdAsync(request.ExpenseId, x => x.Employee);
			if (expense == null)
				throw new KeyNotFoundException("Masraf bulunamadı.");

			var company = await _unitOfWork.Repository<Company>().GetByIdAsync(request.CompanyId);
			var senderIBAN = company.CompanyIBAN;
			var receiverIBAN = expense.Employee?.IBAN;

			if (string.IsNullOrWhiteSpace(senderIBAN) || string.IsNullOrWhiteSpace(receiverIBAN))
				throw new InvalidOperationException("IBAN bilgisi eksik.");

			var approval = new ExpenseApproval
			{
				ExpenseId = request.ExpenseId,
				Status = ExpenseApprovalStatus.Approved,
				Description = request.Description,
				ApprovedById = _userContextService.GetCurrentUserId(),
				ApprovedDate = DateTimeOffset.UtcNow,
				CreatedDate = DateTimeOffset.UtcNow,
				CreatedById = _userContextService.GetCurrentUserId() ?? 0,
				IsActive = true
			};

			await _unitOfWork.Repository<ExpenseApproval>().AddAsync(approval);
			await _unitOfWork.CommitAsync();

			BankTransferRequest bankTransferRequest = new BankTransferRequest
			{
				ExpenseId = request.ExpenseId,
				Amount = expense.Amount,
				SenderIBAN = senderIBAN,
				ReceiverIBAN = receiverIBAN,
				TransferType = TransferType.EFT
			};
			await _bankTransferSimulatorService.TransferAsync(bankTransferRequest);

			await transaction.CommitAsync();
			return ExpenseApprovalConverters.ExpenseApprovalConverter(approval);
		}
		catch
		{
			await transaction.RollbackAsync();
			throw;
		}
	}
}

