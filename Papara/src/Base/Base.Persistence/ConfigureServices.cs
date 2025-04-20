using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using Base.Persistence.DbContext;
using Base.Persistence.Repositories;
using Base.Persistence.UnitOfWork;

namespace Base.Persistence;

public static class ConfigureServices
{
	public static IServiceCollection AddBasePersistence(this IServiceCollection services, IConfiguration configuration)
	{
		var connectionString = configuration.GetConnectionString("MsSqlConnection");

		services.AddDbContext<AppDbContext>(options =>
			options.UseSqlServer(connectionString));

		services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

		services.AddScoped<IUnitOfWork>(sp => new Base.Persistence.UnitOfWork.UnitOfWork(
			sp.GetRequiredService<AppDbContext>(),
			sp.GetRequiredService<IUserContextService>()));

		return services;
	}
}
