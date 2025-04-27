using Microsoft.AspNetCore.Http;

namespace Papara.Application.Features.Finance.ExpenseAttachments.Models;

public class UpdateExpenseAttachmentRequest
{
	public IFormFile File { get; set; }
}
