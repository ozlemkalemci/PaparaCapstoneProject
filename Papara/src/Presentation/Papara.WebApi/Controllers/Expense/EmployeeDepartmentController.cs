using Base.Application.Interfaces;
using Expense.Application.Features.EmployeeDepartments.Commands.Create;
using Expense.Application.Features.EmployeeDepartments.Commands.Delete;
using Expense.Application.Features.EmployeeDepartments.Commands.Update;
using Expense.Application.Features.EmployeeDepartments.Models;
using Expense.Application.Features.EmployeeDepartments.Queries.Get;
using Expense.Application.Features.EmployeeDepartments.Queries.GetAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Papara.WebApi.Controllers.Base;

namespace Papara.WebApi.Controllers.Expense;

[ApiController]
[Route("api/employeedepartments")]
public class EmployeeDepartmentController : ApiControllerBase
{

	public EmployeeDepartmentController()
	{

	}

	[HttpGet]
	[Authorize(Roles = "Admin,Employee")]
	public async Task<IActionResult> GetAll([FromQuery] GetEmployeeDepartmentRequest request)
	{
		var result = await Mediator.Send(new GetAllEmployeeDepartmentsQuery(request));
		return Ok(result);
	}

	[HttpGet("{id:long}")]
	[Authorize(Roles = "Admin,Employee")]
	public async Task<IActionResult> GetById(long id)
	{
		var result = await Mediator.Send(new GetEmployeeDepartmentByIdQuery(id));
		return Ok(result);
	}

	[HttpPost]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> Create([FromBody] CreateEmployeeDepartmentRequest request)
	{
		var result = await Mediator.Send(new CreateEmployeeDepartmentCommand(request));
		return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
	}

	[HttpPut("{id:long}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> Update(long id, [FromBody] UpdateEmployeeDepartmentRequest request)
	{
		var result = await Mediator.Send(new UpdateEmployeeDepartmentCommand(id, request));
		return Ok(result);
	}

	[HttpDelete("{id:long}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> Delete(long id)
	{
		await Mediator.Send(new DeleteEmployeeDepartmentCommand(id));
		return NoContent();
	}
}