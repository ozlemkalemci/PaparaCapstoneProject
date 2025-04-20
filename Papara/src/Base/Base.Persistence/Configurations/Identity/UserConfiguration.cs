using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Base.Domain.Identity;
using Base.Persistence.Configurations.Base;

namespace Base.Persistence.Configurations.Identity;

public class UserConfiguration : BaseEntityConfiguration<User>
{
	public override void Configure(EntityTypeBuilder<User> builder)
	{
		builder.ToTable("Users", "Base");

		base.Configure(builder);

		builder.Property(u => u.UserName)
			.IsRequired()
			.HasMaxLength(100);

		builder.HasIndex(x => x.UserName).IsUnique(true);

		builder.Property(u => u.PasswordHash)
			.IsRequired();

		builder.Property(u => u.Secret)
			.HasMaxLength(250);

		builder.Property(u => u.Role)
			.IsRequired(true)
			.HasConversion<byte>();

		builder.Property(u => u.OpenDate)
			.IsRequired();

		builder.Property(u => u.LastLoginDate)
			.IsRequired(false);
	}
}