using MediatR;
using Papara.Application.Features.Finance.ExpenseReports.Models;
using Papara.Domain.Enums.Finance;

namespace Papara.Application.Features.Finance.ExpenseReports.Queries.GetExpenseApprovalStatusSummary;

public class GetExpenseApprovalStatusSummaryQuery : IRequest<List<ExpenseApprovalStatusSummaryResponse>>
{
	public ReportPeriod Period { get; set; } = ReportPeriod.Weekly;
}
