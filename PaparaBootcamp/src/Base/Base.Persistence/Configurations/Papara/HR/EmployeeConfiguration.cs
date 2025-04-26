using Base.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papara.Domain.Entities.HR;

namespace Base.Persistence.Configurations.Papara.HR;

public class EmployeeConfiguration : BaseEntityConfiguration<Employee>
{
	public override void Configure(EntityTypeBuilder<Employee> builder)
	{
		builder.ToTable("Employees", "HR");

		base.Configure(builder);

		builder.Property(e => e.Email)
			.IsRequired()
			.HasMaxLength(150);

		builder.Property(e => e.FirstName)
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(e => e.MiddleName)
			.HasMaxLength(100);

		builder.Property(e => e.LastName)
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(e => e.IdentityNumber)
			.IsRequired()
			.HasMaxLength(11);

		builder.Property(e => e.IBAN)
			.IsRequired()
			.HasMaxLength(34);

		builder.HasOne(e => e.User)
			.WithMany()
			.HasForeignKey(e => e.UserId)
			.IsRequired(false)
			.OnDelete(DeleteBehavior.Restrict);


		builder.HasOne(e => e.Department)
			.WithMany(d => d.Employees)
			.HasForeignKey(e => e.DepartmentId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasMany(e => e.Addresses)
			.WithOne(a => a.Employee)
			.HasForeignKey(a => a.EmployeeId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.HasMany(e => e.Phones)
			.WithOne(p => p.Employee)
			.HasForeignKey(p => p.EmployeeId)
			.OnDelete(DeleteBehavior.Cascade);

		var now = DateTimeOffset.UtcNow;

		builder.HasData(
			
			new Employee
			{
				Id = 1,
				UserId = 1, // admin
				Email = "admin@papara.com",
				FirstName = "Papara",
				MiddleName = null,
				LastName = "Admin",
				IdentityNumber = "23456789012",
				IBAN = "TR000000000000000000000000",
				DepartmentId = 1, // Yönetim
				CreatedDate = now,
				CreatedById = 0,
				IsActive = true
			}, 
			new Employee
			{
				Id = 2,
				UserId = 2, // özlem.kalemci
				Email = "ozlem.kalemci@papara.com",
				FirstName = "Özlem",
				MiddleName = null,
				LastName = "Kalemci",
				IdentityNumber = "12345678901",
				IBAN = "TR000000000000000000000001",
				DepartmentId = 4, // Yazılım Geliştirme
				CreatedDate = now,
				CreatedById = 0,
				IsActive = true
			},
			new Employee
			{
				Id = 3,
				UserId = 3, // personel
				Email = "personel@papara.com",
				FirstName = "Personel",
				MiddleName = null,
				LastName = "Personel",
				IdentityNumber = "34567890123",
				IBAN = "TR000000000000000000000002",
				DepartmentId = 2, // Operasyon
				CreatedDate = now,
				CreatedById = 0,
				IsActive = true
			}
		);
	}
}