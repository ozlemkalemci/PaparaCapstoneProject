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


		builder.Property(p => p.IsPrimary)
			.IsRequired();


		builder.Property(p => p.Type)
			.IsRequired()
			.HasConversion<byte>();

		builder.HasOne(p => p.Employee)
			.WithMany(e => e.Phones)
			.HasForeignKey(p => p.EmployeeId)
			.OnDelete(DeleteBehavior.Restrict);
	}
}