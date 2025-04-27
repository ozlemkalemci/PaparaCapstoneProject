using Papara.Application.Features.Finance.Expenses.Models;

namespace Papara.Application.Features.Finance.ExpenseAttachments.Models;

public class ExpenseAttachmentResponse
{
	public long Id { get; set; }
	public long ExpenseId { get; set; }
	public string OriginalFileName { get; set; } = string.Empty;
	public string StoredFileName { get; set; } = string.Empty;
	public string ContentType { get; set; } = string.Empty;
	public long FileSize { get; set; }
	public string FilePath { get; set; } = string.Empty;
	public string? Description { get; set; }
	public ExpenseResponse? ResponseExpense { get; set; }
}
