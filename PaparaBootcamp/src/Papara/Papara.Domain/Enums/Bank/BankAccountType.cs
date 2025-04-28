using System.ComponentModel.DataAnnotations;

namespace Papara.Domain.Enums.Bank;

public enum BankAccountType : byte
{
	[Display(Name = "Bireysel")]
	Individual = 1,
	[Display(Name = "Kurumsal")]
	Corporate = 2
}
