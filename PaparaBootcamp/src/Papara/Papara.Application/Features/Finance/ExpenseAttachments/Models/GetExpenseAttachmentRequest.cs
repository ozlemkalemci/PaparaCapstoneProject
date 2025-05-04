namespace Papara.Application.Features.Finance.ExpenseAttachments.Models;

public class GetExpenseAttachmentRequest
{
	public long? ExpenseId { get; set; }
	public bool IncludeExpense { get; set; } = false;
}
