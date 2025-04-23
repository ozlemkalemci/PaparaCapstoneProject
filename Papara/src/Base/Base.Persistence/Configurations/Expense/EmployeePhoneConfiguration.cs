using Base.Persistence.Configurations.Base;
using Expense.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Base.Persistence.Configurations.Expense;

public class EmployeePhoneConfiguration : BaseEntityConfiguration<EmployeePhone>
{
	public override void Configure(EntityTypeBuilder<EmployeePhone> builder)
	{
		builder.ToTable("EmployeePhones", "Expense");

		base.Configure(builder);

		builder.Property(p => p.PhoneNumber)
			.IsRequired()
			.HasMaxLength(15);
	}
}
