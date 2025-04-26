using Base.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papara.Domain.Entities.Corporation;

namespace Base.Persistence.Configurations.Papara.Corporation;

public class DepartmentConfiguration : BaseEntityConfiguration<Department>
{
	public override void Configure(EntityTypeBuilder<Department> builder)
	{
		builder.ToTable("Departments", "Corporation");

		base.Configure(builder);

		builder.Property(d => d.DepartmentName)
			.IsRequired()
			.HasMaxLength(150);

		var now = DateTimeOffset.UtcNow;

		builder.HasData(
			new Department
			{
				Id = 1,
				DepartmentName = "Yönetim",
				CreatedDate = now,
				CreatedById = 0,
				IsActive = true
			},
			new Department
			{
				Id = 2,
				DepartmentName = "Operasyon",
				CreatedDate = now,
				CreatedById = 0,
				IsActive = true
			},
			new Department
			{
				Id = 3,
				DepartmentName = "Finans",
				CreatedDate = now,
				CreatedById = 0,
				IsActive = true
			},
			new Department
			{
				Id = 4,
				DepartmentName = "Yazılım Geliştirme",
				CreatedDate = now,
				CreatedById = 0,
				IsActive = true
			}
);

	}
}