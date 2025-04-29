using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using Base.Persistence.DbContext;
using Base.Persistence.Repositories;
using Base.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Base.Persistence;

public static class ConfigureServices
{
	public static IServiceCollection AddBasePersistence(this IServiceCollection services, IConfiguration configuration)
	{
		var connectionString = configuration.GetConnectionString("PaparaSqlConnection");
		var connectionStringBank = configuration.GetConnectionString("BankSqlConnection");

		//services.AddDbContext<AppDbContext>(options =>
		//	options.UseSqlServer(connectionString));

		services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

		services.AddDbContext<BankDbContext>(options => options.UseSqlServer(connectionStringBank, sql => sql.MigrationsAssembly(typeof(BankDbContext).Assembly.FullName)));


		services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
		services.AddScoped(typeof(IBankRepository<>), typeof(BankRepository<>));

		services.AddScoped<IUnitOfWork>(sp => new Base.Persistence.UnitOfWork.UnitOfWork(
			sp.GetRequiredService<AppDbContext>(),
			sp.GetRequiredService<IUserContextService>()));

		services.AddScoped<IBankUnitOfWork>(sp => new BankUnitOfWork(
			sp.GetRequiredService<BankDbContext>()));

		// services.AddHostedService<RefreshTokenCleanerService>(); // şimdilik gereksiz refresh token sonrası soft delete yapıyorum.
		// daha sonra hard delete işlemi için hazırlandı

		return services;
	}
}