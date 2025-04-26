using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Base.Domain.Entities;

namespace Base.Persistence.Configurations.Base;

public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
	public virtual void Configure(EntityTypeBuilder<T> builder)
	{
		builder.HasKey(e => e.Id);
		builder.Property(x => x.Id).UseIdentityColumn();

		builder.Property(e => e.CreatedById).IsRequired(true);
		builder.Property(e => e.CreatedDate).IsRequired(true);

		builder.Property(e => e.UpdatedById).IsRequired(false);
		builder.Property(e => e.UpdatedDate).IsRequired(false);

		builder.Property(e => e.DeletedById).IsRequired(false);
		builder.Property(e => e.DeletedDate).IsRequired(false);

		builder.Property(e => e.IsActive).IsRequired(true);
	}
}