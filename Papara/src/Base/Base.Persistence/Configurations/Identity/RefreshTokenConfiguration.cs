using Base.Domain.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Persistence.Configurations.Identity;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
	public void Configure(EntityTypeBuilder<RefreshToken> builder)
	{
		builder.ToTable("RefreshTokens", "Base");

		builder.HasKey(x => x.Id);

		builder.Property(x => x.TokenHash)
			.IsRequired()
			.HasMaxLength(250);

		builder.Property(x => x.TokenSalt)
			.IsRequired()
			.HasMaxLength(250);

		builder.Property(x => x.Expiration)
			.IsRequired();

		builder.HasOne(x => x.User)
			.WithMany()
			.HasForeignKey(x => x.UserId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}