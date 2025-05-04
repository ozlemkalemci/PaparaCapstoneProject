namespace Papara.Wasm.Shared.Models.Expense;

public class ExpenseApprovalResponse
{
	public long Id { get; set; }
	public long ExpenseId { get; set; }
	public ExpenseApprovalStatus Status { get; set; }
	public string? Description { get; set; }
	public long? ApprovedById { get; set; }
	public DateTimeOffset? ApprovedDate { get; set; }
	public ExpenseResponse? ResponseExpense { get; set; }
}
