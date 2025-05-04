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
			// İlgili masraf kaydını getir, yoksa hata fırlat
			var expense = await GetValidatedExpenseAsync(request.ExpenseId);

			// Masraf için varsa eski beklemede onay kaydını sil, sonuçlanmışsa hata fırlat
			await CheckAndSoftDeletePendingApprovalAsync(request.ExpenseId);

			// Şirket bilgilerini doğrula, yoksa hata fırlat
			var company = await GetValidatedCompanyAsync(request.CompanyId);

			// IBAN’lar kontrol edilir, eksikse hata fırlatılır
			ValidateIBANs(company.CompanyIBAN, expense.Employee?.IBAN);

			// Yeni onay kaydı oluşturulur ve masraf “Concluded” olarak işaretlenir
			var approval = await CreateApprovalAsync(request, expense);

			// Banka transferi simülasyonu gerçekleştirilir
			await SimulateBankTransferAsync(request, expense, company);

			await transaction.CommitAsync();

			return ExpenseApprovalConverters.ExpenseApprovalConverter(approval);
		}
		catch
		{
			await transaction.RollbackAsync();
			throw;
		}
	}


	private async Task<Expense> GetValidatedExpenseAsync(long expenseId)
	{
		var expense = await _unitOfWork.Repository<Expense>().GetByIdAsync(expenseId, x => x.Employee);
		if (expense == null)
			throw new KeyNotFoundException("Masraf bulunamadı.");
		return expense;
	}

	private async Task CheckAndSoftDeletePendingApprovalAsync(long expenseId)
	{
		var approvals = await _unitOfWork.Repository<ExpenseApproval>()
			.Where(x => x.ExpenseId == expenseId && x.IsActive);

		var existing = approvals.FirstOrDefault();

		if (existing?.Status == ExpenseApprovalStatus.Pending)
			_unitOfWork.Repository<ExpenseApproval>().Delete(existing);
		else if (existing != null)
			throw new InvalidOperationException("Bu masraf zaten sonuçlanmış. Yeni onay yapılamaz.");
	}

	private async Task<Company> GetValidatedCompanyAsync(long companyId)
	{
		var company = await _unitOfWork.Repository<Company>().GetByIdAsync(companyId);
		if (company == null)
			throw new KeyNotFoundException("Şirket bulunamadı.");
		return company;
	}

	private void ValidateIBANs(string? sender, string? receiver)
	{
		if (string.IsNullOrWhiteSpace(sender) || string.IsNullOrWhiteSpace(receiver))
			throw new InvalidOperationException("IBAN bilgisi eksik.");
	}

	private async Task<ExpenseApproval> CreateApprovalAsync(CreateAndTransferApprovalRequest request, Expense expense)
	{
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

		expense.Concluded = true;
		_unitOfWork.Repository<Expense>().Update(expense);

		await _unitOfWork.CommitAsync();
		return approval;
	}

	private async Task SimulateBankTransferAsync(CreateAndTransferApprovalRequest request, Expense expense, Company company)
	{
		var transfer = new BankTransferRequest
		{
			ExpenseId = request.ExpenseId,
			Amount = expense.Amount,
			SenderIBAN = company.CompanyIBAN,
			ReceiverIBAN = expense.Employee?.IBAN,
			TransferType = TransferType.EFT
		};

		await _bankTransferSimulatorService.TransferAsync(transfer);
	}
}

