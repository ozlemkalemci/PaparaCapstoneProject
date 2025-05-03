using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Papara.Application.Features.Finance.ExpenseTypes.Commands.Create;
using Papara.Application.Features.Finance.ExpenseTypes.Commands.Delete;
using Papara.Application.Features.Finance.ExpenseTypes.Commands.Update;
using Papara.Application.Features.Finance.ExpenseTypes.Queries.Get;
using Papara.Application.Features.Finance.ExpenseTypes.Queries.GetAll;
using Papara.Application.Features.Finance.ExpenseTypes.Models;
using Papara.WebApi.Controllers.Base;

namespace Papara.WebApi.Controllers.Papara.Finance;

[ApiController]
[Route("api/expensetypes")]
public class ExpenseTypeController : ApiControllerBase
{
	public ExpenseTypeController()
	{
	}

	/// <summary>
	/// Tüm masraf türlerini listeler.
	/// </summary>
	/// <returns>Masraf türleri listesi</returns>
	[HttpGet]
	[Authorize(Roles = "Admin,Employee")]
	public async Task<IActionResult> GetAll()
	{
		var result = await Mediator.Send(new GetAllExpenseTypesQuery());
		return Ok(result);
	}

	/// <summary>
	/// Belirli bir masraf türünü ID bilgisine göre getirir.
	/// </summary>
	/// <param name="id">Masraf türü ID bilgisi</param>
	/// <returns>Masraf türü detayları</returns>
	[HttpGet("{id:long}")]
	[Authorize(Roles = "Admin,Employee")]
	public async Task<IActionResult> GetById(long id)
	{
		var result = await Mediator.Send(new GetExpenseTypeByIdQuery(id));
		return Ok(result);
	}

	/// <summary>
	/// Yeni bir masraf türü oluşturur.
	/// </summary>
	/// <param name="request">Masraf türü oluşturma isteği</param>
	/// <returns>Oluşturulan masraf türü</returns>
	[HttpPost]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> Create([FromBody] CreateExpenseTypeRequest request)
	{
		var result = await Mediator.Send(new CreateExpenseTypeCommand(request));
		return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
	}

	/// <summary>
	/// Var olan bir masraf türünü günceller.
	/// </summary>
	/// <param name="id">Masraf türü ID</param>
	/// <param name="request">Güncelleme isteği</param>
	/// <returns>Güncellenmiş masraf türü</returns>
	[HttpPut("{id:long}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> Update(long id, [FromBody] UpdateExpenseTypeRequest request)
	{
		var result = await Mediator.Send(new UpdateExpenseTypeCommand(id, request));
		return Ok(result);
	}

	/// <summary>
	/// Belirli bir masraf türünü siler.
	/// </summary>
	/// <param name="id">Silinecek masraf türünün ID bilgisi</param>
	[HttpDelete("{id:long}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> Delete(long id)
	{
		await Mediator.Send(new DeleteExpenseTypeCommand(id));
		return NoContent();
	}
}
