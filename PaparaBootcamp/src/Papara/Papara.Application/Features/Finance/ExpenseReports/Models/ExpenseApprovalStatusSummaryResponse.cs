using Papara.Domain.Enums.Finance;

namespace Papara.Application.Features.Finance.ExpenseReports.Models;

public class ExpenseApprovalStatusSummaryResponse
{
	public ReportPeriod Period { get; set; }
	public ExpenseApprovalStatus Status { get; set; }
	public decimal TotalAmount { get; set; }
	public int Count { get; set; }
}
