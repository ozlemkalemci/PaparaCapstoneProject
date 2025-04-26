using Base.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papara.Domain.Entities.Finance;

namespace Base.Persistence.Configurations.Papara.Finance
{
	public class ExpenseApprovalConfiguration : BaseEntityConfiguration<ExpenseApproval>
	{
		public override void Configure(EntityTypeBuilder<ExpenseApproval> builder)
		{
			builder.ToTable("ExpenseApprovals", "Finance");

			base.Configure(builder);

			builder.Property(x => x.Status)
				.IsRequired()
				.HasConversion<byte>();

			builder.Property(x => x.Description)
				.HasMaxLength(500);

			builder.Property(x => x.ApprovedById)
				.IsRequired(false);

			builder.Property(x => x.ApprovedDate)
				.IsRequired(false);
		}
	}
}
