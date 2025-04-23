using Base.Application.Behaviors;
using Expense.Application.Features.Employees.Commands.Create;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Expense.Application;

public static class ConfigureServices
{
	public static IServiceCollection AddExpenseApplicationServices(this IServiceCollection services)
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