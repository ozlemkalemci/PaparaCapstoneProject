using System.ComponentModel.DataAnnotations;

namespace Papara.Domain.Enums.Hr;

public enum PhoneType : byte
{
	[Display(Name = "Mobil")]
	Mobile = 1,

	[Display(Name = "Ev")]
	Home = 2,

	[Display(Name = "İş")]
	Work = 3,
}