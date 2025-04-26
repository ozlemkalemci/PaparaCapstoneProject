using Papara.Application.Features.HR.EmployeePhones.Commands.Create;
using Papara.Application.Features.HR.EmployeePhones.Commands.Delete;
using Papara.Application.Features.HR.EmployeePhones.Commands.Update;
using Papara.Application.Features.HR.EmployeePhones.Queries.Get;
using Papara.Application.Features.HR.EmployeePhones.Queries.GetAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Papara.WebApi.Controllers.Base;
using Papara.Application.Features.HR.EmployeePhones.Models;

namespace Papara.WebApi.Controllers.Papara.HR;

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