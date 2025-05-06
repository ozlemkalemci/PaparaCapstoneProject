using System.ComponentModel.DataAnnotations;

namespace Papara.Domain.Enums.Finance;

public enum PaymentMethod : byte
{
	[Display(Name = "Nakit")]
	Cash = 1,          
	[Display(Name = "Kredi Kartı")]
	CreditCard = 2,    
	[Display(Name = "Şirket Kartı")]
	CompanyCard = 3,   
	[Display(Name = "Havale/EFT")]
	BankTransfer = 4,  
	[Display(Name = "Diğer")]
	Other = 5         
}
