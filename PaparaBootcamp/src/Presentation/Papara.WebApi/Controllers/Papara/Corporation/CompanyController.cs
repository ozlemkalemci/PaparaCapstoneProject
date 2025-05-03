using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Papara.Application.Features.Corporation.Companies.Commands.Create;
using Papara.Application.Features.Corporation.Companies.Commands.Delete;
using Papara.Application.Features.Corporation.Companies.Commands.Update;
using Papara.Application.Features.Corporation.Companies.Models;
using Papara.Application.Features.Corporation.Companies.Queries.Get;
using Papara.Application.Features.Corporation.Companies.Queries.GetAll;
using Papara.WebApi.Controllers.Base;

namespace Papara.WebApi.Controllers.Papara.Corporation;

[ApiController]
[Route("api/companies")]
[Authorize(Roles = "Admin")]
public class CompanyController : ApiControllerBase
{
	public CompanyController()
	{
	}

	/// <summary>
	/// Tüm şirket kayıtlarını filtrelenmiş şekilde getirir.
	/// </summary>
	/// <param name="request">Filtre parametreleri</param>
	/// <returns>Şirket listesi</returns>
	[HttpGet]
	public async Task<IActionResult> GetAll([FromQuery] GetCompanyRequest request)
	{
		var result = await Mediator.Send(new GetAllCompaniesQuery(request));
		return Ok(result);
	}

	/// <summary>
	/// Belirli bir şirketi ID'ye göre getirir.
	/// </summary>
	/// <param name="id">Şirket ID</param>
	/// <returns>Şirket bilgisi</returns>
	[HttpGet("{id:long}")]
	public async Task<IActionResult> GetById(long id)
	{
		var result = await Mediator.Send(new GetCompanyByIdQuery(id));
		return Ok(result);
	}

	/// <summary>
	/// Yeni bir şirket oluşturur.
	/// </summary>
	/// <param name="request">Yeni şirket bilgileri</param>
	/// <returns>Oluşturulan şirket</returns>
	[HttpPost]
	public async Task<IActionResult> Create([FromBody] CreateCompanyRequest request)
	{
		var result = await Mediator.Send(new CreateCompanyCommand(request));
		return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
	}

	/// <summary>
	/// Mevcut bir şirketi günceller.
	/// </summary>
	/// <param name="id">Güncellenecek şirketin ID'si</param>
	/// <param name="request">Yeni bilgiler</param>
	/// <returns>Güncellenmiş şirket bilgisi</returns>
	[HttpPut("{id:long}")]
	public async Task<IActionResult> Update(long id, [FromBody] UpdateCompanyRequest request)
	{
		var result = await Mediator.Send(new UpdateCompanyCommand(id, request));
		return Ok(result);
	}

	/// <summary>
	/// Belirli bir şirketi siler.
	/// </summary>
	/// <param name="id">Silinecek şirketin ID'si</param>
	[HttpDelete("{id:long}")]
	public async Task<IActionResult> Delete(long id)
	{
		await Mediator.Send(new DeleteCompanyCommand(id));
		return NoContent();
	}
}
