using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Papara.Application.Features.Bank.BankAccounts.Commands.Create;
using Papara.Application.Features.Bank.BankAccounts.Commands.Delete;
using Papara.Application.Features.Bank.BankAccounts.Commands.Update;
using Papara.Application.Features.Bank.BankAccounts.Models;
using Papara.Application.Features.Bank.BankAccounts.Queries.Get;
using Papara.Application.Features.Bank.BankAccounts.Queries.GetAll;
using Papara.WebApi.Controllers.Base;

namespace Papara.WebApi.Controllers.Papara.Bank;

[ApiController]
[Route("api/bank-accounts")]
[Authorize(Roles = "Admin")]
public class BankAccountController : ApiControllerBase
{
	public BankAccountController()
	{
	}

	/// <summary>
	/// Tüm banka hesaplarını listeler.
	/// </summary>
	/// <returns>Banka hesaplarının listesi</returns>
	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var result = await Mediator.Send(new GetAllBankAccountsQuery());
		return Ok(result);
	}

	/// <summary>
	/// Belirli bir banka hesabını ID'ye göre getirir.
	/// </summary>
	/// <param name="id">Banka hesap ID</param>
	/// <returns>Banka hesap bilgileri</returns>
	[HttpGet("{id:long}")]
	public async Task<IActionResult> GetById(long id)
	{
		var result = await Mediator.Send(new GetBankAccountByIdQuery(id));
		return Ok(result);
	}

	/// <summary>
	/// Yeni bir banka hesabı oluşturur.
	/// </summary>
	/// <param name="request">Oluşturulacak hesap bilgileri</param>
	/// <returns>Oluşturulan banka hesabı bilgileri</returns>
	[HttpPost]
	public async Task<IActionResult> Create([FromBody] CreateBankAccountRequest request)
	{
		var result = await Mediator.Send(new CreateBankAccountCommand(request));
		return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
	}

	/// <summary>
	/// Var olan bir banka hesabını günceller.
	/// </summary>
	/// <param name="id">Güncellenecek hesap ID</param>
	/// <param name="request">Yeni bilgiler</param>
	/// <returns>Güncellenmiş banka hesabı</returns>
	[HttpPut("{id:long}")]
	public async Task<IActionResult> Update(long id, [FromBody] UpdateBankAccountRequest request)
	{
		var result = await Mediator.Send(new UpdateBankAccountCommand(id, request));
		return Ok(result);
	}

	/// <summary>
	/// Belirli bir banka hesabını siler.
	/// </summary>
	/// <param name="id">Silinecek hesap ID</param>
	[HttpDelete("{id:long}")]
	public async Task<IActionResult> Delete(long id)
	{
		await Mediator.Send(new DeleteBankAccountCommand(id));
		return NoContent();
	}
}
