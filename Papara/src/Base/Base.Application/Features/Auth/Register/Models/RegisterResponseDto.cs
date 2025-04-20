using Base.Domain.Enums;

namespace Base.Application.Features.Auth.Register.Models;

public class RegisterResponseDto
{
	public long UserId { get; set; }
	public string UserName { get; set; } = null!;
	public UserRole Role { get; set; }
}