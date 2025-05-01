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

	public DepartmentController()
	{

	}

	[HttpGet]
	[Authorize(Roles = "Admin,Employee")]
	public async Task<IActionResult> GetAll([FromQuery] GetDepartmentRequest request)
	{
		var result = await Mediator.Send(new GetAllDepartmentsQuery(request));
		return Ok(result);
	}

	[HttpGet("{id:long}")]
	[Authorize(Roles = "Admin,Employee")]
	public async Task<IActionResult> GetById(long id)
	{
		var result = await Mediator.Send(new GetDepartmentByIdQuery(id));
		return Ok(result);
	}

	[HttpPost]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> Create([FromBody] CreateDepartmentRequest request)
	{
		var result = await Mediator.Send(new CreateDepartmentCommand(request));
		return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
	}

	[HttpPut("{id:long}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> Update(long id, [FromBody] UpdateDepartmentRequest request)
	{
		var result = await Mediator.Send(new UpdateDepartmentCommand(id, request));
		return Ok(result);
	}

	[HttpDelete("{id:long}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> Delete(long id)
	{
		await Mediator.Send(new DeleteDepartmentCommand(id));
		return NoContent();
	}
}