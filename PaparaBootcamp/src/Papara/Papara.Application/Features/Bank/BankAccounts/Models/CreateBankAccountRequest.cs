using Papara.Domain.Enums.Bank;

namespace Papara.Application.Features.Bank.BankAccounts.Models;

public class CreateBankAccountRequest
{
	public string AccountHolderName { get; set; } = string.Empty;
	public string IBAN { get; set; } = string.Empty;
	public string? IdentityNumber { get; set; }
	public string? TaxNumber { get; set; }
	public BankAccountType AccountType { get; set; }
}
