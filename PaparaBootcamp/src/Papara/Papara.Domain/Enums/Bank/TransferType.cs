using System.ComponentModel.DataAnnotations;

namespace Papara.Domain.Enums.Bank;

public enum TransferType : byte
{
	[Display(Name = "Havale")]
	Havale = 1,
	[Display(Name = "EFT")]
	EFT = 2
}
