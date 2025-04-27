using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papara.Domain.Entities.Finance;
using Base.Persistence.Configurations.Base;

namespace Papara.Persistence.Configurations.Finance;

public class ExpenseAttachmentConfiguration : BaseEntityConfiguration<ExpenseAttachment>
{
	public override void Configure(EntityTypeBuilder<ExpenseAttachment> builder)
	{
		builder.ToTable("ExpenseAttachments", "Finance");

		base.Configure(builder);

		builder.Property(x => x.OriginalFileName)
			.IsRequired()
			.HasMaxLength(250);

		builder.Property(x => x.StoredFileName)
			.IsRequired()
			.HasMaxLength(250);

		builder.Property(x => x.ContentType)
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(x => x.FilePath)
			.IsRequired()
			.HasMaxLength(500);

		builder.Property(x => x.FileSize)
			.IsRequired();

		builder.Property(x => x.Description)
			.HasMaxLength(500);

		builder.HasOne(x => x.Expense)
			.WithMany(x => x.Attachments)
			.HasForeignKey(x => x.ExpenseId);
	}
}
