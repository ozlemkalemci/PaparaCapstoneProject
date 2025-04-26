using Base.Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Papara.Application.Features.HR.Employees.Commands.Create;

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

		return services;
	}
}