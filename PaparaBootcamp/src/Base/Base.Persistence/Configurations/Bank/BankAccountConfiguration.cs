using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papara.Domain.Entities.Bank;
using Papara.Domain.Enums.Bank;

namespace Base.Persistence.Configurations.Papara.Bank
{
	public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
	{
		public void Configure(EntityTypeBuilder<BankAccount> builder)
		{
			builder.ToTable("BankAccounts", "Bank");

			builder.HasKey(x => x.Id);

			builder.Property(x => x.AccountHolderName)
				.IsRequired()
				.HasMaxLength(200);

			builder.Property(x => x.IBAN)
				.IsRequired()
				.HasMaxLength(34);

			builder.Property(x => x.AccountType)
				.IsRequired();

			// SEED
			var now = DateTimeOffset.UtcNow;
			builder.HasData(
				new BankAccount
				{
					Id = 1,
					AccountHolderName = "Papara Şirketi",
					IBAN = "TR000000000000000000000999",
					TaxNumber = "1234567890",
					AccountType = BankAccountType.Corporate,
		
				},
				new BankAccount
				{
					Id = 2,
					AccountHolderName = "Özlem Kalemci",
					IBAN = "TR000000000000000000000001",
					IdentityNumber = "12345678901",
					AccountType = BankAccountType.Individual,
				
				},
				new BankAccount
				{
					Id = 3,
					AccountHolderName = "Personel Personel",
					IBAN = "TR000000000000000000000002",
					IdentityNumber = "34567890123",
					AccountType = BankAccountType.Individual,
					
				}
			);
		}
	}
}
