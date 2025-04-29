using Base.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Papara.Domain.Entities.Corporation;
using Papara.Domain.Entities.HR;
using Papara.Domain.Entities.Finance;
using Papara.Domain.Entities.Bank;

namespace Base.Persistence.DbContext;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

	// Base
	public DbSet<User> Users => Set<User>();
	public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

	// Papara
	public DbSet<Company> Companies => Set<Company>();
	public DbSet<Expense> Expenses => Set<Expense>();
	public DbSet<ExpenseApproval> ExpenseApprovals => Set<ExpenseApproval>();
	public DbSet<ExpenseAttachment> ExpenseAttachments => Set<ExpenseAttachment>();
	public DbSet<ExpenseType> ExpenseTypes => Set<ExpenseType>();
	public DbSet<Employee> Employees => Set<Employee>();
	public DbSet<EmployeeAddress> EmployeeAddresses => Set<EmployeeAddress>();
	public DbSet<EmployeePhone> EmployeePhones => Set<EmployeePhone>();
	public DbSet<Department> Departments => Set<Department>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

		modelBuilder.Ignore<BankAccount>();
		modelBuilder.Ignore<ExpensePayment>();

		base.OnModelCreating(modelBuilder);
	}
}