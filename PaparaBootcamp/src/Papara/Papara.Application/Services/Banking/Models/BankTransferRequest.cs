using Papara.Domain.Enums.Bank;

namespace Papara.Application.Services.Banking.Models;

public class BankTransferRequest
{
	public string SenderIBAN { get; set; } = string.Empty;
	public string ReceiverIBAN { get; set; } = string.Empty;
	public decimal Amount { get; set; }
	public TransferType TransferType { get; set; }
	public long? ExpenseId { get; set; }
}
