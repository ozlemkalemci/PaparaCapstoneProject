using Papara.Domain.Enums.Finance;
using System.ComponentModel.DataAnnotations;

namespace Papara.Application.Features.Finance.ExpenseReports.Models;

public class AdminExpenseSummaryResponse
{
	public ReportPeriod Period { get; set; }
	public decimal TotalAmount { get; set; }
	public int ExpenseCount { get; set; }
}
