using Base.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papara.Domain.Entities.Finance;

namespace Base.Persistence.Configurations.Papara.Finance
{
	public class ExpenseAttachmentConfiguration : BaseEntityConfiguration<ExpenseAttachment>
	{
		public override void Configure(EntityTypeBuilder<ExpenseAttachment> builder)
		{
			builder.ToTable("ExpenseAttachments", "Finance");

			base.Configure(builder);

			builder.Property(x => x.FilePath)
				.IsRequired()
				.HasMaxLength(300);

			builder.HasOne(x => x.Expense)
				.WithMany(x => x.Attachments)
				.HasForeignKey(x => x.ExpenseId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
