using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Base.Application.Behaviors;
using Base.Application.Features.Auth.Logins.Validators;


namespace Base.Application;

public static class ConfigureServices
{
	public static IServiceCollection AddBaseApplicationServices(this IServiceCollection services)
	{
		services.AddValidatorsFromAssembly(typeof(LoginCommandValidator).Assembly);

		services.AddMediatR(cfg =>
		{
			cfg.RegisterServicesFromAssembly(typeof(ConfigureServices).Assembly);
		});

		services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

		return services;
	}
}