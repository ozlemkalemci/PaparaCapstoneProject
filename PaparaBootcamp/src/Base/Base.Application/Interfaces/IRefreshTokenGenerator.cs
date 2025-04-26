namespace Base.Application.Interfaces;

public interface IRefreshTokenGenerator
{
	string GenerateToken();
	(string Hash, string Salt) HashToken(string token);
	bool VerifyToken(string token, string hash, string salt);
}