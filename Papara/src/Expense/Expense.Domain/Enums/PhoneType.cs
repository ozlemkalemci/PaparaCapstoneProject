using System.ComponentModel.DataAnnotations;

namespace Expense.Domain.Enums;

public enum PhoneType : byte
{
	[Display(Name = "Mobil")]
	Mobile = 1,

	[Display(Name = "Ev")]
	Home = 2,

	[Display(Name = "İş")]
	Work = 3,
}