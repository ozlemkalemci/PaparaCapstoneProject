using Base.Persistence.Configurations.Base;
using Expense.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Base.Persistence.Configurations.Expense;

public class EmployeeAddressConfiguration : BaseEntityConfiguration<EmployeeAddress>
{
	public override void Configure(EntityTypeBuilder<EmployeeAddress> builder)
	{
		builder.ToTable("EmployeeAddresses", "Expense");

		base.Configure(builder);

		builder.Property(a => a.City)
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(a => a.District)
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(a => a.Detail)
			.IsRequired()
			.HasMaxLength(500);
	}
}
