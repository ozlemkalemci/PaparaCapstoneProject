using Papara.Domain.Enums.Finance;

namespace Papara.Application.Features.Finance.ExpenseApprovals.Models;

public class GetExpenseApprovalRequest
{
//	public long? EmployeeId { get; set; }
	public long? ExpenseId { get; set; }
	public bool IncludeExpense { get; set; } = false;
	public ExpenseApprovalStatus? Status { get; set; }
}
