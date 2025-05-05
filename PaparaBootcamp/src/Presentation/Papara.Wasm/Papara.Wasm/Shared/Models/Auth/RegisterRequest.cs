using System.ComponentModel.DataAnnotations;

namespace Papara.Wasm.Shared.Models.Auth;

public class RegisterRequest
{
	public string UserName { get; set; } = null!;
	public string Password { get; set; } = null!;
	public UserRole Role { get; set; }
	public string Email { get; set; } = null!;
}

public enum UserRole : byte
{
	[Display(Name = "Admin")]
	Admin = 1,

	[Display(Name = "Personel")]
	Employee = 2,
}