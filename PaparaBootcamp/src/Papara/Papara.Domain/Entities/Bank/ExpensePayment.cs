using Base.Domain.Entities;
using Papara.Domain.Enums.Bank;

namespace Papara.Domain.Entities.Bank;

public class ExpensePayment
{
	public long Id { get; set; }
	public long ExpenseId { get; set; }
	public decimal Amount { get; set; }
	public DateTimeOffset PaymentDate { get; set; }
	public bool IsSuccessful { get; set; }
	public string? PaymentReferenceNumber { get; set; }

	public string SenderIBAN { get; set; } = string.Empty;
	public string ReceiverIBAN { get; set; } = string.Empty;
	public TransferType TransferType { get; set; } = TransferType.EFT;
}
