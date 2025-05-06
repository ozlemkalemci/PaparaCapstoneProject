namespace Papara.Wasm.Shared.Models.Expense.ExpenseApprovals;

public class CreateExpenseApprovalRequest
{
	public long ExpenseId { get; set; }
	public ExpenseApprovalStatus Status { get; set; }
	public string? Description { get; set; }
}
