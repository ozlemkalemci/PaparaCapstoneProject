using Base.Domain.Entities;
using Papara.Domain.Enums.Bank;

namespace Papara.Domain.Entities.Bank;

public class BankAccount
{
	public long Id { get; set; }
	public string AccountHolderName { get; set; } = string.Empty; // Ad Soyad / Şirket Adı
	public string IBAN { get; set; } = string.Empty;
	public string? IdentityNumber { get; set; } // TC No (opsiyonel)
	public string? TaxNumber { get; set; } // Vergi No (opsiyonel)

	public BankAccountType AccountType { get; set; } // Bireysel veya Kurumsal
}
