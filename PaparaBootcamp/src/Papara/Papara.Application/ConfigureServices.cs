using Base.Application.Behaviors;
using Base.Application.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Papara.Application.Features.HR.Employees.Commands.Create;
using Papara.Application.Services.Auth;

namespace Papara.Application;

public static class ConfigureServices
{
	public static IServiceCollection AddPaparaApplicationServices(this IServiceCollection services)
	{
		services.AddValidatorsFromAssembly(typeof(CreateEmployeeCommandValidator).Assembly);

		services.AddMediatR(cfg =>
		{
			cfg.RegisterServicesFromAssembly(typeof(ConfigureServices).Assembly);
		});

		services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
		services.AddScoped<IUserService, UserService>();
		return services;
	}
}