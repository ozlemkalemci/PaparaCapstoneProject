using Base.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Papara.Domain.Entities.Corporation;
using Papara.Domain.Entities.HR;

namespace Base.Persistence.DbContext
{
	public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		// Base
		public DbSet<User> Users => Set<User>();
		public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

		// Papara
		public DbSet<Employee> Employees => Set<Employee>();
		public DbSet<EmployeeAddress> EmployeeAddresses => Set<EmployeeAddress>();
		public DbSet<EmployeePhone> EmployeePhones => Set<EmployeePhone>();
		public DbSet<Department> Departments => Set<Department>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			base.OnModelCreating(modelBuilder);
		}
	}
}