using Base.Application.Interfaces;
using Papara.Application.Features.HR.Employees.Commands.Create;
using Papara.Application.Features.HR.Employees.Commands.Delete;
using Papara.Application.Features.HR.Employees.Commands.Update;
using Papara.Application.Features.HR.Employees.Queries.Get;
using Papara.Application.Features.HR.Employees.Queries.GetAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Papara.WebApi.Controllers.Base;
using System.Security.Claims;
using Papara.Application.Features.HR.Employees.Models;

namespace Papara.WebApi.Controllers.Papara.HR;

[ApiController]
[Route("api/employees")]
public class EmployeesController : ApiControllerBase
{
	private readonly IUserContextService _userContextService;

	public EmployeesController(IUserContextService userContextService)
	{
		_userContextService = userContextService;
	}

	[HttpGet]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> GetAll([FromQuery] GetEmployeeRequest request)
	{
		var result = await Mediator.Send(new GetAllEmployeesQuery(request));
		return Ok(result);
	}

	[HttpGet("{id:long}")]
	[Authorize(Roles = "Admin,Employee")]
	public async Task<IActionResult> GetById(long id)
	{
		var result = await Mediator.Send(new GetEmployeeByIdQuery(id));
		return Ok(result);
	}

	[HttpPost]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> Create([FromBody] CreateEmployeeRequest request)
	{
		var result = await Mediator.Send(new CreateEmployeeCommand(request));
		return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
	}

	[HttpPut("{id:long}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> Update(long id, [FromBody] UpdateEmployeeRequest request)
	{
		var result = await Mediator.Send(new UpdateEmployeeCommand(id, request));
		return Ok(result);
	}

	[HttpDelete("{id:long}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> Delete(long id)
	{
		await Mediator.Send(new DeleteEmployeeCommand(id));
		return NoContent();
	}
}