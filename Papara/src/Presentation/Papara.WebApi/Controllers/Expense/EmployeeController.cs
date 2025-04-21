using Base.Application.Interfaces;
using Expense.Application.Features.Employees.Commands.Create;
using Expense.Application.Features.Employees.Commands.Delete;
using Expense.Application.Features.Employees.Commands.Update;
using Expense.Application.Features.Employees.Models;
using Expense.Application.Features.Employees.Queries.Get;
using Expense.Application.Features.Employees.Queries.GetAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Papara.WebApi.Controllers.Base;
using System.Security.Claims;

namespace Papara.WebApi.Controllers.Expense;

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

	[HttpGet]
	[Authorize(Roles = "Admin,Employee")]
	public async Task<IActionResult> GetById(long id)
	{
		var currentUserId = _userContextService.GetCurrentUserId();
		var currentUserRole = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;

		if (currentUserRole == "Employee" && id != currentUserId)
			return Forbid();

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

	[HttpPut]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> Update(long id, [FromBody] UpdateEmployeeRequest request)
	{
		var result = await Mediator.Send(new UpdateEmployeeCommand(id, request));
		return Ok(result);
	}

	[HttpDelete]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> Delete(long id)
	{
		await Mediator.Send(new DeleteEmployeeCommand(id));
		return NoContent();
	}
}