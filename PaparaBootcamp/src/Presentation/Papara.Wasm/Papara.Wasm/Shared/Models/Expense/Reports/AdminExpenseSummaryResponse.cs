using System.ComponentModel.DataAnnotations;

namespace Papara.Wasm.Shared.Models.Expense.Reports;

public class AdminExpenseSummaryResponse
{
	public ReportPeriod Period { get; set; }
	public decimal TotalAmount { get; set; }
	public int ExpenseCount { get; set; }
}
public enum ReportPeriod : byte
{
	[Display(Name = "Günlük")]
	Daily,
	[Display(Name = "Haftalık")]
	Weekly,
	[Display(Name = "Aylık")]
	Monthly
}