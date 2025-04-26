using Base.Application.Interfaces;
using StackExchange.Redis;

namespace Base.Infrastructure.Services.Redis;

public class RedisService : IRedisService
{
	private readonly IDatabase _database;

	public RedisService(IConnectionMultiplexer connection)
	{
		_database = connection.GetDatabase();
	}

	public async Task AddToBlacklistAsync(string jti, DateTimeOffset expiresAt)
	{
		var key = $"blacklist:{jti}";
		var expireIn = expiresAt - DateTimeOffset.UtcNow;
		await _database.StringSetAsync(key, "true", expireIn);
	}

	public async Task<bool> IsBlacklistedAsync(string jti)
	{
		var key = $"blacklist:{jti}";
		return await _database.KeyExistsAsync(key);
	}
}