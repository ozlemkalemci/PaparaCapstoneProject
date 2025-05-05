using Base.Application.Behaviors;
using Base.Application.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Papara.Application.Features.HR.Employees.Commands.Create;
using Papara.Application.Services.Auth;
using Papara.Application.Services.Banking;
using Papara.Application.Services.EmployeeUsers;
using Papara.Application.Services.Finance.Approvals;

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
		services.AddScoped<IExpenseApprovalService, ExpenseApprovalService>();
		services.AddScoped<IEmployeeUserService, EmployeeUserService>();
		services.AddScoped<IBankTransferSimulatorService, BankTransferSimulatorService>();
		return services;
	}
}