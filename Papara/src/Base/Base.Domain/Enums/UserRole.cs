using System.ComponentModel.DataAnnotations;

namespace Base.Domain.Enums;

public enum UserRole : byte
{
	[Display(Name = "Admin")]
	Admin = 1,

	[Display(Name = "Personel")]
	Employee = 2,
}