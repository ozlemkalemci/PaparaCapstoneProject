using Base.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papara.Domain.Entities.HR;
using Papara.Domain.Enums.Hr;

namespace Base.Persistence.Configurations.Papara.HR;

public class EmployeePhoneConfiguration : BaseEntityConfiguration<EmployeePhone>
{
	public override void Configure(EntityTypeBuilder<EmployeePhone> builder)
	{
		builder.ToTable("EmployeePhones", "HR");

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

		var now = DateTimeOffset.UtcNow;

		builder.HasData(
			new EmployeePhone
			{
				Id = 1,
				EmployeeId = 2, // Özlem Kalemci
				PhoneNumber = "5551234567",
				IsPrimary = true,
				Type = PhoneType.Mobile,
				CreatedDate = now,
				CreatedById = 0,
				IsActive = true
			},
			new EmployeePhone
			{
				Id = 2,
				EmployeeId = 3, // Personel
				PhoneNumber = "2129876543",
				IsPrimary = true,
				Type = PhoneType.Work,
				CreatedDate = now,
				CreatedById = 0,
				IsActive = true
			}
		);
	}
}