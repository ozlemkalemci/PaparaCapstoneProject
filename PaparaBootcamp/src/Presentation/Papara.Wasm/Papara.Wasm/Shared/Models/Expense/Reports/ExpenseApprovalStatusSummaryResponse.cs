using Papara.Wasm.Shared.Models.Expense.ExpenseApprovals;

namespace Papara.Wasm.Shared.Models.Expense.Reports;

public class ExpenseApprovalStatusSummaryResponse
{
	public ReportPeriod Period { get; set; }
	public ExpenseApprovalStatus Status { get; set; }
	public decimal TotalAmount { get; set; }
	public int Count { get; set; }
}
