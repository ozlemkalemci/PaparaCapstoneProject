using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace Papara.Wasm.Shared.Models.Expense;

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
}
