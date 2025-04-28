using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papara.Domain.Entities.Bank;

namespace Base.Persistence.Configurations.Bank;

public class ExpensePaymentConfiguration : IEntityTypeConfiguration<ExpensePayment>
{
	public void Configure(EntityTypeBuilder<ExpensePayment> builder)
	{
		builder.ToTable("ExpensePayments", "Bank");

		builder.HasKey(x => x.Id);

		builder.Property(x => x.ExpenseId)
			.IsRequired();

		builder.Property(x => x.Amount)
			.HasColumnType("decimal(18,2)")
			.IsRequired();

		builder.Property(x => x.PaymentDate)
			.IsRequired();

		builder.Property(x => x.IsSuccessful)
			.IsRequired();

		builder.Property(x => x.PaymentReferenceNumber)
			.HasMaxLength(100);

		builder.Property(x => x.SenderIBAN)
			.IsRequired()
			.HasMaxLength(34);

		builder.Property(x => x.ReceiverIBAN)
			.IsRequired()
			.HasMaxLength(34);

		builder.Property(x => x.TransferType)
			.IsRequired();
	}
}