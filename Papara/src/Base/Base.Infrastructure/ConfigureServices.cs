using Base.Application.Interfaces;
using Base.Infrastructure.Services;
using Base.Infrastructure.Services.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Base.Infrastructure;

public static class ConfigureServices
{
	public static IServiceCollection AddBaseInfrastructure(this IServiceCollection services)
	{
		services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

		services.AddScoped<IUserContextService, UserContextService>();
		services.AddScoped<IJwtService, JwtService>();
		services.AddScoped<IPasswordHasher, PasswordHasher>();

		return services;
	}
}