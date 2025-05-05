namespace Papara.Wasm.Shared.Models.Expense.ExpenseAttachments;

public class ExpenseAttachmentResponse
{
	public long Id { get; set; }
	public long ExpenseId { get; set; }
	public string FilePath { get; set; } = string.Empty;
	public string? Description { get; set; }
}
