using Base.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Papara.Application.Features.Finance.Expenses.Commands.Create;
using Papara.Application.Features.Finance.Expenses.Commands.Update;
using Papara.Application.Features.Finance.Expenses.Commands.Delete;
using Papara.Application.Features.Finance.Expenses.Queries.GetAll;
using Papara.Application.Features.Finance.Expenses.Queries.Get;
using Papara.WebApi.Controllers.Base;
using System.Security.Claims;
using Papara.Application.Features.Finance.Expenses.Models;

namespace Papara.WebApi.Controllers.Papara.Finance
{
	[ApiController]
	[Route("api/expenses")]
	public class ExpensesController : ApiControllerBase
	{
		private readonly IUserContextService _userContextService;

		public ExpensesController(IUserContextService userContextService)
		{
			_userContextService = userContextService;
		}

		[HttpGet]
		[Authorize(Roles = "Admin,Employee")]
		public async Task<IActionResult> GetAll([FromQuery] GetExpenseRequest request)
		{
			var result = await Mediator.Send(new GetAllExpensesQuery(request));
			return Ok(result);
		}

		[HttpGet("{id:long}")]
		[Authorize(Roles = "Admin,Employee")]
		public async Task<IActionResult> GetById(long id)
		{
			var result = await Mediator.Send(new GetExpenseByIdQuery(id));
			return Ok(result);
		}


		[HttpPost]
		[Authorize(Roles = "Employee")]
		public async Task<IActionResult> Create([FromBody] CreateExpenseRequest request)
		{			
			var result = await Mediator.Send(new CreateExpenseCommand(request));
			return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
		}

		[HttpPut("{id:long}")]
		[Authorize(Roles = "Employee")]
		public async Task<IActionResult> Update(long id, [FromBody] UpdateExpenseRequest request)
		{			
			var result = await Mediator.Send(new UpdateExpenseCommand(id, request));
			return Ok(result);
		}

		[HttpDelete("{id:long}")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Delete(long id)
		{
			await Mediator.Send(new DeleteExpenseCommand(id));
			return NoContent();
		}
	}
}
