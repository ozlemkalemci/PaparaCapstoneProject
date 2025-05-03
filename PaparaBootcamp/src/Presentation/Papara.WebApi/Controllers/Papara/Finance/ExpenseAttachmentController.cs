using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Papara.WebApi.Controllers.Base;
using Papara.Application.Features.Finance.ExpenseAttachments.Commands.Create;
using Papara.Application.Features.Finance.ExpenseAttachments.Commands.Update;
using Papara.Application.Features.Finance.ExpenseAttachments.Commands.Delete;
using Papara.Application.Features.Finance.ExpenseAttachments.Models;
using Papara.Application.Features.Finance.ExpenseAttachments.Queries.Get;
using Papara.Application.Features.Finance.ExpenseAttachments.Queries.GetAll;

namespace Papara.WebApi.Controllers.Papara.Finance;

[ApiController]
[Route("api/expenseattachments")]
[Authorize(Roles = "Admin,Employee")]
public class ExpenseAttachmentController : ApiControllerBase
{
	public ExpenseAttachmentController() { }

	/// <summary>
	/// Masraf ekine ait tüm dosyaları listeler. İsteğe bağlı filtre uygulanabilir.
	/// </summary>
	/// <param name="request">Filtreleme kriterleri</param>
	/// <returns>Ek dosya listesi</returns>
	[HttpGet]
	public async Task<IActionResult> GetAll([FromQuery] GetExpenseAttachmentRequest request)
	{
		var result = await Mediator.Send(new GetAllExpenseAttachmentsQuery(request));
		return Ok(result);
	}

	/// <summary>
	/// Belirli bir masraf ek dosyasını ID ile getirir.
	/// </summary>
	/// <param name="id">Ek dosya ID</param>
	/// <returns>Ek dosya bilgisi</returns>
	[HttpGet("{id:long}")]
	public async Task<IActionResult> GetById(long id)
	{
		var result = await Mediator.Send(new GetExpenseAttachmentByIdQuery(id));
		return Ok(result);
	}

	/// <summary>
	/// Yeni bir masraf ek dosyası yükler.
	/// </summary>
	/// <param name="request">Dosya ve açıklama bilgisi içeren form verisi</param>
	/// <returns>Oluşturulan dosya bilgisi</returns>
	[HttpPost]
	public async Task<IActionResult> Create([FromForm] CreateExpenseAttachmentRequest request)
	{
		var result = await Mediator.Send(new CreateExpenseAttachmentCommand(
			request.ExpenseId, request.File, request.Description));
		return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
	}

	/// <summary>
	/// Mevcut bir masraf ek dosyasını günceller.
	/// </summary>
	/// <param name="id">Güncellenecek ek dosyanın ID'si</param>
	/// <param name="request">Yeni dosya ve açıklama</param>
	/// <returns>Güncellenmiş dosya bilgisi</returns>
	[HttpPut("{id:long}")]
	public async Task<IActionResult> Update(long id, [FromForm] UpdateExpenseAttachmentRequest request)
	{
		var result = await Mediator.Send(new UpdateExpenseAttachmentCommand(id, request));
		return Ok(result);
	}

	/// <summary>
	/// Belirli bir masraf ek dosyasını siler.
	/// </summary>
	/// <param name="id">Silinecek dosya ID</param>
	[HttpDelete("{id:long}")]
	public async Task<IActionResult> Delete(long id)
	{
		await Mediator.Send(new DeleteExpenseAttachmentCommand(id));
		return NoContent();
	}
}
