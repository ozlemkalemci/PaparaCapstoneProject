namespace Papara.Wasm.Shared.Models.Expense;

public class PersonnelExpenseReportResponse
{
	public long ExpenseId { get; set; }
	public DateTimeOffset ExpenseDate { get; set; }
	public decimal Amount { get; set; }
	public string Description { get; set; } = string.Empty;
	public ExpenseApprovalStatus Status { get; set; }
	public string ExpenseType { get; set; } = string.Empty;
}
