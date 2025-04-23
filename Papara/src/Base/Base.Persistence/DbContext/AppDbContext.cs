using Base.Domain.Identity;
using Expense.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Base.Persistence.DbContext
{
	public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		// Base
		public DbSet<User> Users => Set<User>();
		public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

		// Expense
		public DbSet<Employee> Employees => Set<Employee>();
		public DbSet<EmployeeAddress> EmployeeAddresses => Set<EmployeeAddress>();
		public DbSet<EmployeePhone> EmployeePhones => Set<EmployeePhone>();
		public DbSet<EmployeeDepartment> EmployeeDepartments => Set<EmployeeDepartment>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			base.OnModelCreating(modelBuilder);
		}
	}
}