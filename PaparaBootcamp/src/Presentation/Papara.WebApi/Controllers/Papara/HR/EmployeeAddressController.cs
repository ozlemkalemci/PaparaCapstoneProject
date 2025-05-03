using Papara.Application.Features.HR.EmployeeAddresses.Commands.Create;
using Papara.Application.Features.HR.EmployeeAddresses.Commands.Delete;
using Papara.Application.Features.HR.EmployeeAddresses.Commands.Update;
using Papara.Application.Features.HR.EmployeeAddresses.Queries.Get;
using Papara.Application.Features.HR.EmployeeAddresses.Queries.GetAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Papara.WebApi.Controllers.Base;
using Papara.Application.Features.HR.EmployeeAddresses.Models;

namespace Papara.WebApi.Controllers.Papara.HR;

[ApiController]
[Route("api/employeeaddresses")]
[Authorize(Roles = "Admin,Employee")]
public class EmployeeAddressController : ApiControllerBase
{
	public EmployeeAddressController()
	{
	}

	/// <summary>
	/// Tüm çalışan adreslerini listeler.
	/// </summary>
	/// <param name="request">Filtreleme seçenekleri</param>
	/// <returns>Adres listesi</returns>
	[HttpGet]
	public async Task<IActionResult> GetAll([FromQuery] GetEmployeeAddressRequest request)
	{
		var result = await Mediator.Send(new GetAllEmployeeAddressesQuery(request));
		return Ok(result);
	}

	/// <summary>
	/// Belirli bir çalışanın adresini ID'ye göre getirir.
	/// </summary>
	/// <param name="id">Adres ID</param>
	/// <returns>Adres bilgisi</returns>
	[HttpGet("{id:long}")]
	public async Task<IActionResult> GetById(long id)
	{
		var result = await Mediator.Send(new GetEmployeeAddressByIdQuery(id));
		return Ok(result);
	}

	/// <summary>
	/// Yeni bir çalışan adresi oluşturur.
	/// </summary>
	/// <param name="request">Adres oluşturma isteği</param>
	/// <returns>Oluşturulan adres</returns>
	[HttpPost]
	public async Task<IActionResult> Create([FromBody] CreateEmployeeAddressRequest request)
	{
		var result = await Mediator.Send(new CreateEmployeeAddressCommand(request));
		return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
	}

	/// <summary>
	/// Çalışan adresini günceller.
	/// </summary>
	/// <param name="id">Adres ID</param>
	/// <param name="request">Güncelleme isteği</param>
	/// <returns>Güncellenmiş adres</returns>
	[HttpPut("{id:long}")]
	public async Task<IActionResult> Update(long id, [FromBody] UpdateEmployeeAddressRequest request)
	{
		var result = await Mediator.Send(new UpdateEmployeeAddressCommand(id, request));
		return Ok(result);
	}

	/// <summary>
	/// Çalışan adresini siler.
	/// </summary>
	/// <param name="id">Silinecek adresin ID'si</param>
	[HttpDelete("{id:long}")]
	public async Task<IActionResult> Delete(long id)
	{
		await Mediator.Send(new DeleteEmployeeAddressCommand(id));
		return NoContent();
	}
}
