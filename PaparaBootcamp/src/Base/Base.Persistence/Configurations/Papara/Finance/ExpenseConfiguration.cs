using Base.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papara.Domain.Entities.Finance;

namespace Base.Persistence.Configurations.Papara.Finance
{
	public class ExpenseConfiguration : BaseEntityConfiguration<Expense>
	{
		public override void Configure(EntityTypeBuilder<Expense> builder)
		{
			builder.ToTable("Expenses", "Finance");

			base.Configure(builder);

			builder.Property(x => x.Amount)
				.IsRequired()
				.HasColumnType("decimal(18,2)");

			builder.Property(x => x.Description)
				.IsRequired()
				.HasMaxLength(500);

			builder.Property(x => x.ExpenseDate)
				.IsRequired();

			builder.HasOne(x => x.Employee)
				.WithMany()
				.HasForeignKey(x => x.EmployeeId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(x => x.ExpenseType)
				.WithMany(x => x.Expenses)
				.HasForeignKey(x => x.ExpenseTypeId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Property(x => x.Concluded)
				.IsRequired()
				.HasDefaultValue(false);

			builder.HasMany(x => x.Attachments)
				.WithOne(x => x.Expense)
				.HasForeignKey(x => x.ExpenseId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasMany(x => x.Approvals)
				.WithOne(x => x.Expense)
				.HasForeignKey(x => x.ExpenseId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
