using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Papara.WebApi.Controllers.Base;
using Papara.Application.Features.Finance.ExpenseAttachments.Commands.Create;
using Papara.Application.Features.Finance.ExpenseAttachments.Commands.Update;
using Papara.Application.Features.Finance.ExpenseAttachments.Commands.Delete;
using Papara.Application.Features.Finance.ExpenseAttachments.Models;
using Papara.Application.Features.Finance.ExpenseAttachments.Queries.Get;
using Papara.Application.Features.Finance.ExpenseAttachments.Queries.GetAll;

namespace Papara.WebApi.Controllers.Papara.Finance;

[ApiController]
[Route("api/expenseattachments")]
[Authorize(Roles = "Admin,Employee")]
public class ExpenseAttachmentController : ApiControllerBase
{
	public ExpenseAttachmentController()
	{
	}

	[HttpGet]
	public async Task<IActionResult> GetAll([FromQuery] GetExpenseAttachmentRequest request)
	{
		var result = await Mediator.Send(new GetAllExpenseAttachmentsQuery(request));
		return Ok(result);
	}

	[HttpGet("{id:long}")]
	public async Task<IActionResult> GetById(long id)
	{
		var result = await Mediator.Send(new GetExpenseAttachmentByIdQuery(id));
		return Ok(result);
	}

	[HttpPost]
	public async Task<IActionResult> Create([FromForm] CreateExpenseAttachmentRequest request)
	{
		var result = await Mediator.Send(new CreateExpenseAttachmentCommand(
			request.ExpenseId, request.File, request.Description));
		return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
	}

	[HttpPut("{id:long}")]
	public async Task<IActionResult> Update(long id, [FromForm] UpdateExpenseAttachmentRequest request)
	{
		var result = await Mediator.Send(new UpdateExpenseAttachmentCommand(id, request));
		return Ok(result);
	}

	[HttpDelete("{id:long}")]
	public async Task<IActionResult> Delete(long id)
	{
		await Mediator.Send(new DeleteExpenseAttachmentCommand(id));
		return NoContent();
	}
}
