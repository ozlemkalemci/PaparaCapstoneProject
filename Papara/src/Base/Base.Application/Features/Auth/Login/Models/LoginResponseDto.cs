namespace Base.Application.Features.Auth.Login.Models;

public class LoginResponseDto
{
	public string AccessToken { get; set; } = null!;
	public DateTime Expiration { get; set; }
}