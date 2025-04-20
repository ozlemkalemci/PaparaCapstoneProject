using Expense.Application.Features.Employees.Commands.Create;
using Expense.Application.Features.Employees.Commands.Delete;
using Expense.Application.Features.Employees.Commands.Update;
using Expense.Application.Features.Employees.Models;
using Expense.Application.Features.Employees.Queries.Get;
using Expense.Application.Features.Employees.Queries.GetAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Papara.WebApi.Controllers.Base;

namespace Papara.WebApi.Controllers.Expense;

[ApiController]
[Route("api/employees")]
[Authorize(Roles = "Admin")]
public class EmployeesController : ApiControllerBase
{
	[HttpGet(Name = "GetAllEmployees")]
	public async Task<IActionResult> GetAll([FromQuery] GetEmployeeQueryRequest request)
	{
		var result = await Mediator.Send(new GetAllEmployeesQuery(request));
		return Ok(result);
	}

	[HttpGet("{id:long}", Name = "GetEmployeeById")]
	public async Task<IActionResult> GetById(long id)
	{
		var result = await Mediator.Send(new GetEmployeeByIdQuery(id));
		return Ok(result);
	}

	[HttpPost(Name = "CreateEmployee")]
	public async Task<IActionResult> Create([FromBody] EmployeeRequestDto request)
	{
		var result = await Mediator.Send(new CreateEmployeeCommand(request));
		return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
	}

	[HttpPut("{id:long}", Name = "UpdateEmployee")]
	public async Task<IActionResult> Update(long id, [FromBody] UpdateEmployeeRequestDto request)
	{
		var result = await Mediator.Send(new UpdateEmployeeCommand(id, request));
		return Ok(result);
	}

	[HttpDelete("{id:long}", Name = "DeleteEmployee")]
	public async Task<IActionResult> Delete(long id)
	{
		await Mediator.Send(new DeleteEmployeeCommand(id));
		return NoContent();
	}
}
