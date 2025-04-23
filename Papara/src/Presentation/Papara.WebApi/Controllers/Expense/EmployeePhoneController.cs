using Expense.Application.Features.EmployeePhones.Commands.Create;
using Expense.Application.Features.EmployeePhones.Commands.Delete;
using Expense.Application.Features.EmployeePhones.Commands.Update;
using Expense.Application.Features.EmployeePhones.Models;
using Expense.Application.Features.EmployeePhones.Queries.Get;
using Expense.Application.Features.EmployeePhones.Queries.GetAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Papara.WebApi.Controllers.Base;

namespace Papara.WebApi.Controllers.Expense;

[ApiController]
[Route("api/employeephones")]
[Authorize(Roles = "Admin,Employee")]
public class EmployeePhoneController : ApiControllerBase
{
	public EmployeePhoneController()
	{
	}

	[HttpGet]
	public async Task<IActionResult> GetAll([FromQuery] GetEmployeePhoneRequest request)
	{
		var result = await Mediator.Send(new GetAllEmployeePhonesQuery(request));
		return Ok(result);
	}

	[HttpGet("{id:long}")]
	public async Task<IActionResult> GetById(long id)
	{
		var result = await Mediator.Send(new GetEmployeePhoneByIdQuery(id));
		return Ok(result);
	}

	[HttpPost]
	public async Task<IActionResult> Create([FromBody] CreateEmployeePhoneRequest request)
	{
		var result = await Mediator.Send(new CreateEmployeePhoneCommand(request));
		return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
	}

	[HttpPut("{id:long}")]
	public async Task<IActionResult> Update(long id, [FromBody] UpdateEmployeePhoneRequest request)
	{
		var result = await Mediator.Send(new UpdateEmployeePhoneCommand(id, request));
		return Ok(result);
	}

	[HttpDelete("{id:long}")]
	public async Task<IActionResult> Delete(long id)
	{
		await Mediator.Send(new DeleteEmployeePhoneCommand(id));
		return NoContent();
	}
}