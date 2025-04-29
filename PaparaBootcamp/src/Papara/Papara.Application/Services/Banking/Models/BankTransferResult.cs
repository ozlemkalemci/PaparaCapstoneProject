namespace Papara.Application.Services.Banking.Models;

public class BankTransferResult
{
	public bool IsSuccessful { get; set; }
	public string? PaymentReferenceNumber { get; set; }
	public string? ErrorMessage { get; set; }
}
