namespace Base.Application.Features.Auth.Login.Models;

public class LoginRequestDto
{
	public string UserName { get; set; } = null!;
	public string Password { get; set; } = null!;
}