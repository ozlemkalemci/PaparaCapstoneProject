using Base.Domain.Enums;

namespace Base.Application.Features.Auth.Register.Models;

public class RegisterRequestDto
{
	public string UserName { get; set; } = null!;
	public string Password { get; set; } = null!;
	public UserRole Role { get; set; }
}