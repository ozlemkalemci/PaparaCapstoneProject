namespace Papara.Application.Features.Finance.ExpenseApprovals.Models;

using Papara.Domain.Enums.Finance;

public class CreateExpenseApprovalRequest
{
	public long ExpenseId { get; set; }
	public ExpenseApprovalStatus Status { get; set; }
	public string? Description { get; set; }
}
