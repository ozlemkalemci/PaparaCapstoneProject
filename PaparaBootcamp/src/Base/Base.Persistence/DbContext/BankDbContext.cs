using Base.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Papara.Domain.Entities.Bank;
using Papara.Domain.Entities.Corporation;
using Papara.Domain.Entities.Finance;
using Papara.Domain.Entities.HR;
using System.Reflection;

namespace Base.Persistence.DbContext;

public class BankDbContext : Microsoft.EntityFrameworkCore.DbContext
{
	public BankDbContext(DbContextOptions<BankDbContext> options) : base(options)
	{
	}

	public DbSet<BankAccount> BankAccounts => Set<BankAccount>();
	public DbSet<ExpensePayment> ExpensePayments => Set<ExpensePayment>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

		modelBuilder.Ignore<User>();
		modelBuilder.Ignore<RefreshToken>();
		modelBuilder.Ignore<Company>();
		modelBuilder.Ignore<Expense>();
		modelBuilder.Ignore<ExpenseApproval>();
		modelBuilder.Ignore<ExpenseAttachment>();
		modelBuilder.Ignore<ExpenseType>();
		modelBuilder.Ignore<Employee>();
		modelBuilder.Ignore<EmployeeAddress>();
		modelBuilder.Ignore<EmployeePhone>();
		modelBuilder.Ignore<Department>();

		base.OnModelCreating(modelBuilder);
	}
}
