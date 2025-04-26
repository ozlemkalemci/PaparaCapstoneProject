using Base.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papara.Domain.Entities.HR;

namespace Base.Persistence.Configurations.Papara.HR;

public class EmployeeAddressConfiguration : BaseEntityConfiguration<EmployeeAddress>
{
	public override void Configure(EntityTypeBuilder<EmployeeAddress> builder)
	{
		builder.ToTable("EmployeeAddresses", "HR");

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

		var now = DateTimeOffset.UtcNow;

		builder.HasData(
			new EmployeeAddress
			{
				Id = 1,
				EmployeeId = 2, // Özlem Kalemci
				City = "Eskişehir",
				District = "Tepebaşı",
				Detail = "Çamlıca mahallesi Figen sokak civarı",
				CreatedDate = now,
				CreatedById = 0,
				IsActive = true
			},
			new EmployeeAddress
			{
				Id = 2,
				EmployeeId = 3, // Personel
				City = "İstanbul",
				District = "Kadıköy",
				Detail = "Bahariye Caddesi",
				CreatedDate = now,
				CreatedById = 0,
				IsActive = true
			}
		);

	}
}
