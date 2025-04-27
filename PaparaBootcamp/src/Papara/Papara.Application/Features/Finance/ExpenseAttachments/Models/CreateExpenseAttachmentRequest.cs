using Microsoft.AspNetCore.Http;

namespace Papara.Application.Features.Finance.ExpenseAttachments.Models;

public class CreateExpenseAttachmentRequest
{
	public long ExpenseId { get; set; }
	public IFormFile File { get; set; } = null!;
	public string? Description { get; set; }
}
