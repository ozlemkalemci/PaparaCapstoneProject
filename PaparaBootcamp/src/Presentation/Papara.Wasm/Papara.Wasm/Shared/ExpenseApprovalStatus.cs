using System.ComponentModel.DataAnnotations;

namespace Papara.Wasm.Shared;

public enum ExpenseApprovalStatus : byte
{
	[Display(Name = "Bekliyor")]
	Pending = 1,
	[Display(Name = "Onaylandı")]
	Approved = 2,
	[Display(Name = "Reddedildi")]
	Rejected = 3
}
