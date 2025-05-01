using Papara.Domain.Enums.Finance;

namespace Papara.Application.Features.Finance.ExpenseReports.Models;

public class ExpenseApprovalStatusSummaryResponse
{
	public ReportPeriod Period { get; set; }
	public string Status { get; set; } = string.Empty; // Onaylandı / Reddedildi
	public decimal TotalAmount { get; set; }
	public int Count { get; set; }
}
