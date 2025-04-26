using Base.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papara.Domain.Entities.Finance;

namespace Base.Persistence.Configurations.Finance;

public class ExpenseTypeConfiguration : BaseEntityConfiguration<ExpenseType>
{
	public override void Configure(EntityTypeBuilder<ExpenseType> builder)
	{
		builder.ToTable("ExpenseTypes", "Finance");

		base.Configure(builder);

		builder.Property(x => x.Name)
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(x => x.Description)
			.IsRequired()
			.HasMaxLength(300);

		// Seeding
		builder.HasData(
			new ExpenseType { Id = 1, Name = "Ulaşım", Description = "Ulaşım biletleri (uçak, tren, taksi vb.)", IsActive = true, CreatedById = 0, CreatedDate = DateTimeOffset.UtcNow },
			new ExpenseType { Id = 2, Name = "Araç Giderleri", Description = "Yakıt, bakım, otopark, otoyol geçişleri", IsActive = true, CreatedById = 0, CreatedDate = DateTimeOffset.UtcNow },
			new ExpenseType { Id = 3, Name = "Yemek", Description = "Kişisel yemek harcamaları", IsActive = true, CreatedById =0, CreatedDate = DateTimeOffset.UtcNow },
			new ExpenseType { Id = 4, Name = "Konaklama", Description = "Otel, konaklama giderleri", IsActive = true, CreatedById = 0, CreatedDate = DateTimeOffset.UtcNow },
			new ExpenseType { Id = 5, Name = "Sağlık Harcamaları", Description = "İlaç, hastane, tedavi vs.", IsActive = true, CreatedById = 0, CreatedDate = DateTimeOffset.UtcNow },
			new ExpenseType { Id = 6, Name = "Eğitim ve Sertifikalar", Description = "Eğitim programları, sertifika ücretleri", IsActive = true, CreatedById =0, CreatedDate = DateTimeOffset.UtcNow },
			new ExpenseType { Id = 7, Name = "Telekomünikasyon", Description = "GSM faturaları, internet", IsActive = true, CreatedById = 0, CreatedDate = DateTimeOffset.UtcNow },
			new ExpenseType { Id = 8, Name = "Ofis ve Kırtasiye Giderleri", Description = "Ofis ekipmanları, kırtasiye", IsActive = true, CreatedById = 0, CreatedDate = DateTimeOffset.UtcNow },
			new ExpenseType { Id = 9, Name = "Ağırlama ve İkram", Description = "Müşteri ağırlama, toplantı ikramları", IsActive = true, CreatedById = 0, CreatedDate = DateTimeOffset.UtcNow }
		);
	}
}
