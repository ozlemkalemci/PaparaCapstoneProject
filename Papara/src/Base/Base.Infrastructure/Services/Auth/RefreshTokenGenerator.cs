using Base.Application.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Base.Infrastructure.Services.Auth;

public class RefreshTokenGenerator : IRefreshTokenGenerator
{
	public string GenerateToken()
	{
		var bytes = new byte[64];
		using var rng = RandomNumberGenerator.Create();
		rng.GetBytes(bytes);
		return Convert.ToBase64String(bytes);
	}

	public (string Hash, string Salt) HashToken(string token)
	{
		var salt = Guid.NewGuid().ToString("N");
		using var sha256 = SHA256.Create();
		var combined = Encoding.UTF8.GetBytes(token + salt);
		var hash = sha256.ComputeHash(combined);
		return (Convert.ToBase64String(hash), salt);
	}

	public bool VerifyToken(string token, string hash, string salt)
	{
		using var sha256 = SHA256.Create();
		var combined = Encoding.UTF8.GetBytes(token + salt);
		var computedHash = sha256.ComputeHash(combined);
		return Convert.ToBase64String(computedHash) == hash;
	}
}