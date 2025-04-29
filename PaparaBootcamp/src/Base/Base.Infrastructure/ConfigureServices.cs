using Base.Application.Interfaces;
using Base.Infrastructure.Services;
using Base.Infrastructure.Services.Auth;
using Base.Infrastructure.Services.File;
using Base.Infrastructure.Services.Redis;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Base.Infrastructure;

public static class ConfigureServices
{
	public static IServiceCollection AddBaseInfrastructure(this IServiceCollection services)
	{
		services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

		services.AddScoped<IUserContextService, UserContextService>();
		services.AddScoped<IJwtService, JwtService>();
		services.AddScoped<IPasswordHasher, PasswordHasher>();

		services.AddScoped<IRefreshTokenGenerator, RefreshTokenGenerator>();

		// Redis kayıtları
		//services.AddSingleton<IConnectionMultiplexer>(
		//	_ => ConnectionMultiplexer.Connect("localhost:6379"));
		//services.AddScoped<IRedisService, RedisService>();

		services.AddSingleton<IConnectionMultiplexer>(provider =>
		{
			var configuration = provider.GetRequiredService<IConfiguration>();
			var redisConnectionString = configuration.GetValue<string>("RedisConnection");
			return ConnectionMultiplexer.Connect(redisConnectionString);
		});

		services.AddScoped<IFileService, LocalFileService>();

		return services;
	}
}