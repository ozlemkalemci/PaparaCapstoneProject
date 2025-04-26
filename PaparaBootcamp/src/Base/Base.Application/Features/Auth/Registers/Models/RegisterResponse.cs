using Base.Domain.Enums;

namespace Base.Application.Features.Auth.Registers.Models;

public class RegisterResponse
{
	public long UserId { get; set; }
	public string UserName { get; set; } = null!;
	public UserRole Role { get; set; }
	public string Email { get; set; } = null!;
}