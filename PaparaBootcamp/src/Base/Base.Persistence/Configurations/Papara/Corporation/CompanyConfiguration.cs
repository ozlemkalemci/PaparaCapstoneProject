using Base.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papara.Domain.Entities.Corporation;

namespace Base.Persistence.Configurations.Papara.Corporation;

public class CompanyConfiguration : BaseEntityConfiguration<Company>
{
	public override void Configure(EntityTypeBuilder<Company> builder)
	{
		builder.ToTable("Companies", "Corporation");

		base.Configure(builder);

		builder.Property(x => x.CompanyName)
			.IsRequired()
			.HasMaxLength(200);

		builder.Property(x => x.TaxNumber)
			.IsRequired()
			.HasMaxLength(10);

		builder.Property(x => x.CompanyIBAN)
			.IsRequired()
			.HasMaxLength(34);

		// SEED
		builder.HasData(new Company
		{
			Id = 1,
			CompanyName = "Papara Şirketi",
			TaxNumber = "1234567890",
			CompanyIBAN = "TR000000000000000000000999",
			CreatedDate = DateTimeOffset.UtcNow,
			CreatedById = 0,
			IsActive = true
		});
	}
}
