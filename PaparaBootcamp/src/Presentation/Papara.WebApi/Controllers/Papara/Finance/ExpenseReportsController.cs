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
	/// Personelin kendi işlem hareketlerini getirir.
	/// </summary>
	/// <remarks>
	/// Personelin kendi taleplerini ve detaylarını görebileceği rapordur.
	/// </remarks>
	[HttpGet("personnel-expense-history")]
	public async Task<IActionResult> GetPersonnelExpenseHistory([FromQuery] GetPersonnelExpenseHistoryQuery query)
	{
		var result = await Mediator.Send(query);
		return Ok(result);
	}

	/// <summary>
	/// Günlük, haftalık ve aylık toplam ödeme özetini getirir.
	/// </summary>
	/// <remarks>
	/// Şirket yönetimi tarafından toplam ödeme yoğunluğunu izlemek için kullanılır.
	/// </remarks>
	[HttpGet("admin-summary")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> GetAdminSummary([FromQuery] GetAdminExpenseSummaryReportQuery query)
	{
		var result = await Mediator.Send(query);
		return Ok(result);
	}

	/// <summary>
	/// Personel bazlı günlük, haftalık ve aylık harcama özetlerini getirir.
	/// </summary>
	/// <remarks>
	/// Şirketin personel bazlı harcama yoğunluğunu dönemsel olarak analiz etmesini sağlar.
	/// </remarks>
	[HttpGet("personnel-spending-summary")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> GetPersonnelSpendingSummary([FromQuery] GetPersonnelSpendingSummaryQuery query)
	{
		var result = await Mediator.Send(query);
		return Ok(result);
	}

	/// <summary>
	/// Onay ve red durumlarına göre masraf sayı ve tutarlarını getirir.
	/// </summary>
	/// <remarks>
	/// Günlük, haftalık ve aylık dönemlerde masraf onay/red istatistiklerini raporlamak için kullanılır.
	/// </remarks>
	[HttpGet("approval-status-summary")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> GetApprovalStatusSummary([FromQuery] GetExpenseApprovalStatusSummaryQuery query)
	{
		var result = await Mediator.Send(query);
		return Ok(result);
	}

}
