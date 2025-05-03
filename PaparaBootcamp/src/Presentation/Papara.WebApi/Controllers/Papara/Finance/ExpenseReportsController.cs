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
	/// Belirli bir çalışanın geçmiş masraf işlemlerini getirir.
	/// </summary>
	/// <remarks>
	/// Personelin kendi harcama geçmişini görmesi için geliştirilmiştir.
	/// </remarks>
	[HttpGet("personnel-expense-history")]
	public async Task<IActionResult> GetPersonnelExpenseHistory([FromQuery] GetPersonnelExpenseHistoryQuery query)
	{
		var result = await Mediator.Send(query);
		return Ok(result);
	}

	/// <summary>
	/// Günlük, haftalık veya aylık toplam masraf özetini getirir.
	/// </summary>
	/// <remarks>
	/// Şirket yönetimi tarafından masraf yoğunluğunu izlemek için kullanılır.
	/// </remarks>
	[HttpGet("admin-summary")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> GetAdminSummary([FromQuery] GetAdminExpenseSummaryReportQuery query)
	{
		var result = await Mediator.Send(query);
		return Ok(result);
	}

	/// <summary>
	/// Personel bazlı harcama özetlerini (günlük, haftalık, aylık) getirir.
	/// </summary>
	/// <remarks>
	/// Personellerin harcama yoğunluğunun dönemsel analizini sağlar.
	/// </remarks>
	[HttpGet("personnel-spending-summary")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> GetPersonnelSpendingSummary([FromQuery] GetPersonnelSpendingSummaryQuery query)
	{
		var result = await Mediator.Send(query);
		return Ok(result);
	}

	/// <summary>
	/// Onay ve red durumlarına göre masraf sayısını ve tutarlarını raporlar.
	/// </summary>
	/// <remarks>
	/// Masraf onay süreçlerinin dönemsel performansını izlemek için kullanılır.
	/// </remarks>
	[HttpGet("approval-status-summary")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> GetApprovalStatusSummary([FromQuery] GetExpenseApprovalStatusSummaryQuery query)
	{
		var result = await Mediator.Send(query);
		return Ok(result);
	}
}
