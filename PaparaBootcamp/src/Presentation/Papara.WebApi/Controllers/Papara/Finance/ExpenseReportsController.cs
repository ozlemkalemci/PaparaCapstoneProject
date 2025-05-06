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
	/// <summary>
	/// Personelin kendi taleplerini ve detaylarını görebileceği rapordur. Personelin kendi işlem hareketlerini getirir.
	/// </summary>
	[HttpGet("personnel-expense-history")]
	public async Task<IActionResult> GetPersonnelExpenseHistory([FromQuery] GetPersonnelExpenseHistoryQuery query)
	{
		var result = await Mediator.Send(query);
		return Ok(result);
	}

	/// <summary>
	/// Şirket yönetimi tarafından toplam ödeme yoğunluğunu izlemek için kullanılır. Günlük, haftalık ve aylık toplam ödeme özetini getirir.
	/// </summary>
	[HttpGet("admin-summary")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> GetAdminSummary([FromQuery] GetAdminExpenseSummaryReportQuery query)
	{
		var result = await Mediator.Send(query);
		return Ok(result);
	}

	/// <summary>
	/// Şirketin personel bazlı harcama yoğunluğunu dönemsel olarak analiz etmesini sağlar.
	/// </summary>
	[HttpGet("personnel-spending-summary")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> GetPersonnelSpendingSummary([FromQuery] GetPersonnelSpendingSummaryQuery query)
	{
		var result = await Mediator.Send(query);
		return Ok(result);
	}

	/// <summary>
	/// Günlük, haftalık ve aylık dönemlerde masraf onay/red istatistiklerini raporlamak için kullanılır.
	/// </summary>
	[HttpGet("approval-status-summary")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> GetApprovalStatusSummary([FromQuery] GetExpenseApprovalStatusSummaryQuery query)
	{
		var result = await Mediator.Send(query);
		return Ok(result);
	}

}
