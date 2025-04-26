namespace Base.Application.Features.Auth.Logins.Models;

public class LoginResponse
{
	public string AccessToken { get; set; } = null!;
	public DateTime Expiration { get; set; }
	public string RefreshToken { get; set; } = null!;
	public DateTimeOffset RefreshTokenExpiration { get; set; }
}