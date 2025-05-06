using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace Papara.Wasm.Shared.Models.Expense.Expenses;

public class CreateExpenseRequest
{
	[Required]
	public long EmployeeId { get; set; }

	[Required]
	public decimal Amount { get; set; }

	[Required]
	public string Description { get; set; } = string.Empty;

	[Required]
	public DateTimeOffset ExpenseDate { get; set; } = DateTimeOffset.Now;

	[Required]
	public long ExpenseTypeId { get; set; }
	public string? Location { get; set; }
	public PaymentMethod PaymentMethod { get; set; }
}
public enum PaymentMethod : byte
{
	[Display(Name = "Nakit")]
	Cash = 1,
	[Display(Name = "Kredi Kartı")]
	CreditCard = 2,
	[Display(Name = "Şirket Kartı")]
	CompanyCard = 3,
	[Display(Name = "Havale/EFT")]
	BankTransfer = 4,
	[Display(Name = "Diğer")]
	Other = 5
}