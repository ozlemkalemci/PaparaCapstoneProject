using MediatR;
using Microsoft.AspNetCore.Http;
using Papara.Application.Features.Finance.ExpenseAttachments.Models;

namespace Papara.Application.Features.Finance.ExpenseAttachments.Commands.Create;

public class CreateExpenseAttachmentCommand : IRequest<ExpenseAttachmentResponse>
{
	public long ExpenseId { get; set; }
	public IFormFile File { get; set; }
	public string? Description { get; set; }

	public CreateExpenseAttachmentCommand(long expenseId, IFormFile file, string? description = null)
	{
		ExpenseId = expenseId;
		File = file;
		Description = description;
	}
}
