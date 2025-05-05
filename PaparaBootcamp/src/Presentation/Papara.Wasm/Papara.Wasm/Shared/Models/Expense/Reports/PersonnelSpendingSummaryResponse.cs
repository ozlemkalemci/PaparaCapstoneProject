namespace Papara.Wasm.Shared.Models.Expense.Reports;

public class PersonnelSpendingSummaryResponse
{
	public ReportPeriod Period { get; set; }
	public string FullName { get; set; } = string.Empty;
	public decimal TotalAmount { get; set; }
	public int ExpenseCount { get; set; }
}
