using Base.Domain.Entities;
using Papara.Domain.Enums.Finance;

namespace Papara.Domain.Entities.Finance;

public class ExpenseApproval : BaseEntity
{
	public long ExpenseId { get; set; }
	public Expense Expense { get; set; } = null!;

	public ExpenseApprovalStatus Status { get; set; } = ExpenseApprovalStatus.Pending; 
	public string? Description { get; set; }

	public long ApprovedById { get; set; }
	public DateTimeOffset ApprovedDate { get; set; }
}
