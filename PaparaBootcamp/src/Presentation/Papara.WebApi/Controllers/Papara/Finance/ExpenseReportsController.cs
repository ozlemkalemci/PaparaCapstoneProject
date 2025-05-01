using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Papara.WebApi.Controllers.Base;
using Papara.Application.Features.Finance.ExpenseReports.Queries.GetAdminExpenseSummaryReport;
using Papara.Application.Features.Finance.ExpenseReports.Queries.GetExpenseApprovalStatusSummary;
using Papara.Application.Features.Finance.ExpenseReports.Queries.GetPersonnelExpenseHistory;
using Papara.Application.Features.Finance.ExpenseReports.Queries.GetPersonnelSpendingSummary;

namespace Papara.WebApi.Controllers.Papara.Finance;

[ApiController]
[Route("api/expensereports")]
[Authorize(Roles = "Admin,Employee")]
public class ExpenseReportsController : ApiControllerBase
{
	[HttpGet("personnel-expense-history")]
	public async Task<IActionResult> GetPersonnelExpenseHistory([FromQuery] GetPersonnelExpenseHistoryQuery query)
	{
		var result = await Mediator.Send(query);
		return Ok(result);
	}

	[HttpGet("admin-summary")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> GetAdminSummary([FromQuery] GetAdminExpenseSummaryReportQuery query)
	{
		var result = await Mediator.Send(query);
		return Ok(result);
	}

	[HttpGet("personnel-spending-summary")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> GetPersonnelSpendingSummary([FromQuery] GetPersonnelSpendingSummaryQuery query)
	{
		var result = await Mediator.Send(query);
		return Ok(result);
	}

	[HttpGet("approval-status-summary")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> GetApprovalStatusSummary([FromQuery] GetExpenseApprovalStatusSummaryQuery query)
	{
		var result = await Mediator.Send(query);
		return Ok(result);
	}
}
