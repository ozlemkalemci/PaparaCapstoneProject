namespace Base.Application.Interfaces;

public interface IRedisService
{
	Task AddToBlacklistAsync(string jti, DateTimeOffset expiresAt);
	Task<bool> IsBlacklistedAsync(string jti);
}