using Base.Persistence.Configurations.Base;
using Expense.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Base.Persistence.Configurations.Expense;

public class EmployeeConfiguration : BaseEntityConfiguration<Employee>
{
	public override void Configure(EntityTypeBuilder<Employee> builder)
	{
		builder.ToTable("Employees", "Expense");

		base.Configure(builder);

		builder.Property(e => e.Email)
			.IsRequired()
			.HasMaxLength(150);

		builder.Property(e => e.FirstName)
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(e => e.MiddleName)
			.HasMaxLength(100);

		builder.Property(e => e.LastName)
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(e => e.IdentityNumber)
			.IsRequired()
			.HasMaxLength(11);

		builder.Property(e => e.IBAN)
			.IsRequired()
			.HasMaxLength(34);

		builder.HasOne(e => e.User)
			.WithMany()
			.HasForeignKey(e => e.UserId)
			.IsRequired(false)
			.OnDelete(DeleteBehavior.Restrict);


		builder.HasOne(e => e.Department)
			.WithMany(d => d.Employees)
			.HasForeignKey(e => e.DepartmentId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasMany(e => e.Addresses)
			.WithOne(a => a.Employee)
			.HasForeignKey(a => a.EmployeeId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.HasMany(e => e.Phones)
			.WithOne(p => p.Employee)
			.HasForeignKey(p => p.EmployeeId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}