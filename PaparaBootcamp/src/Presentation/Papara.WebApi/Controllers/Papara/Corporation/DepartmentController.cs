using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Papara.Application.Features.Corporation.Departments.Commands.Create;
using Papara.Application.Features.Corporation.Departments.Commands.Delete;
using Papara.Application.Features.Corporation.Departments.Commands.Update;
using Papara.Application.Features.Corporation.Departments.Models;
using Papara.Application.Features.Corporation.Departments.Queries.Get;
using Papara.Application.Features.Corporation.Departments.Queries.GetAll;
using Papara.WebApi.Controllers.Base;

namespace Papara.WebApi.Controllers.Papara.Corporation;

[ApiController]
[Route("api/departments")]
public class DepartmentController : ApiControllerBase
{
	public DepartmentController() { }

	/// <summary>
	/// Tüm departmanları getirir. İsteğe bağlı filtreleme desteklenir.
	/// </summary>
	/// <param name="request">Filtreleme parametreleri</param>
	/// <returns>Departman listesi</returns>
	[HttpGet]
	[Authorize(Roles = "Admin,Employee")]
	public async Task<IActionResult> GetAll([FromQuery] GetDepartmentRequest request)
	{
		var result = await Mediator.Send(new GetAllDepartmentsQuery(request));
		return Ok(result);
	}

	/// <summary>
	/// Belirli bir departmanı ID'ye göre getirir.
	/// </summary>
	/// <param name="id">Departman ID</param>
	/// <returns>Departman detayları</returns>
	[HttpGet("{id:long}")]
	[Authorize(Roles = "Admin,Employee")]
	public async Task<IActionResult> GetById(long id)
	{
		var result = await Mediator.Send(new GetDepartmentByIdQuery(id));
		return Ok(result);
	}

	/// <summary>
	/// Yeni bir departman oluşturur.
	/// </summary>
	/// <param name="request">Oluşturulacak departman bilgisi</param>
	/// <returns>Oluşturulan departman</returns>
	[HttpPost]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> Create([FromBody] CreateDepartmentRequest request)
	{
		var result = await Mediator.Send(new CreateDepartmentCommand(request));
		return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
	}

	/// <summary>
	/// Var olan bir departmanı günceller.
	/// </summary>
	/// <param name="id">Güncellenecek departmanın ID'si</param>
	/// <param name="request">Yeni bilgiler</param>
	/// <returns>Güncellenmiş departman bilgisi</returns>
	[HttpPut("{id:long}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> Update(long id, [FromBody] UpdateDepartmentRequest request)
	{
		var result = await Mediator.Send(new UpdateDepartmentCommand(id, request));
		return Ok(result);
	}

	/// <summary>
	/// Belirtilen ID'ye sahip departmanı siler.
	/// </summary>
	/// <param name="id">Silinecek departman ID</param>
	[HttpDelete("{id:long}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> Delete(long id)
	{
		await Mediator.Send(new DeleteDepartmentCommand(id));
		return NoContent();
	}
}
