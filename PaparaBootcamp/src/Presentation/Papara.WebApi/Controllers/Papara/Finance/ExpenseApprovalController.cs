using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Papara.WebApi.Controllers.Base;
using Papara.Application.Features.Finance.ExpenseApprovals.Models;
using Papara.Application.Features.Finance.ExpenseApprovals.Commands.Create;
using Papara.Application.Features.Finance.ExpenseApprovals.Commands.Revert;
using Papara.Application.Features.Finance.ExpenseApprovals.Queries.Get;
using Papara.Application.Features.Finance.ExpenseApprovals.Queries.GetAll;
using MediatR;

namespace Papara.WebApi.Controllers.Papara.Finance
{
	[ApiController]
	[Route("api/expense-approvals")]
	[Authorize(Roles = "Admin")]
	public class ExpenseApprovalController : ApiControllerBase
	{
		public ExpenseApprovalController()
		{
		}

		[HttpGet]
		public async Task<IActionResult> GetAll([FromQuery] GetExpenseApprovalRequest request)
		{
			var result = await Mediator.Send(new GetAllExpenseApprovalsQuery(request));
			return Ok(result);
		}

		[HttpGet("{id:long}")]
		public async Task<IActionResult> GetById(long id)
		{
			var result = await Mediator.Send(new GetExpenseApprovalByIdQuery(id));
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateExpenseApprovalRequest request)
		{
			var result = await Mediator.Send(new CreateExpenseApprovalCommand(request));
			return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
		}

		[HttpPost("revert/{id:long}")]
		public async Task<IActionResult> Revert(long id, [FromBody] string? description)
		{
			var result = await Mediator.Send(new RevertExpenseApprovalCommand(id, description));
			return Ok(result);
		}

	}
}
