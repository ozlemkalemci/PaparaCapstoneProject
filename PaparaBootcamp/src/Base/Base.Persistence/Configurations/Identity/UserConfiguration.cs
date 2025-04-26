using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Base.Domain.Identity;
using Base.Persistence.Configurations.Base;
using Base.Domain.Enums;

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

		builder.Property(e => e.Email)
			.IsRequired()
			.HasMaxLength(150);

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


		// CreatedById = 0 sistem tarafından oluşturuldu anlamına gelmektedir:
		var now = DateTimeOffset.UtcNow;

		builder.HasData(

			new User
			{
				Id = 1,
				UserName = "admin",
				PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123"),
				Email = "admin@papara.com",
				Role = UserRole.Admin,
				Secret = Guid.NewGuid().ToString(),
				OpenDate = now,
				CreatedDate = now,
				CreatedById = 0,
				IsActive = true
			},
			new User
			{
				Id = 2,
				UserName = "ozlem.kalemci",
				PasswordHash = BCrypt.Net.BCrypt.HashPassword("Ozlem123"),
				Email = "ozlem.kalemci@papara.com",
				Role = UserRole.Employee,
				Secret = Guid.NewGuid().ToString(),
				OpenDate = now,
				CreatedDate = now,
				CreatedById = 0,
				IsActive = true
			},
			new User
			{
				Id = 3,
				UserName = "personel1",
				PasswordHash = BCrypt.Net.BCrypt.HashPassword("personel123"),
				Email = "personel@papara.com",
				Role = UserRole.Employee,
				Secret = Guid.NewGuid().ToString(),
				OpenDate = now,
				CreatedDate = now,
				CreatedById = 0,
				IsActive = true
			}
		);
	}
}