using Base.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Papara.Application.Features.Finance.Expenses.Commands.Create;
using Papara.Application.Features.Finance.Expenses.Commands.Update;
using Papara.Application.Features.Finance.Expenses.Commands.Delete;
using Papara.Application.Features.Finance.Expenses.Queries.GetAll;
using Papara.Application.Features.Finance.Expenses.Queries.Get;
using Papara.WebApi.Controllers.Base;
using Papara.Application.Features.Finance.Expenses.Models;

namespace Papara.WebApi.Controllers.Papara.Finance
{
	[ApiController]
	[Route("api/expenses")]
	[Authorize(Roles = "Admin,Employee")]
	public class ExpensesController : ApiControllerBase
	{
		private readonly IUserContextService _userContextService;

		public ExpensesController(IUserContextService userContextService)
		{
			_userContextService = userContextService;
		}

		/// <summary>
		/// Tüm masraf kayıtlarını filtreleyerek listeler.
		/// </summary>
		/// <param name="request">Filtreleme parametreleri</param>
		/// <returns>Masraf listesi</returns>
		[HttpGet]
		
		public async Task<IActionResult> GetAll([FromQuery] GetExpenseRequest request)
		{
			var result = await Mediator.Send(new GetAllExpensesQuery(request));
			return Ok(result);
		}

		/// <summary>
		/// Belirli bir masraf kaydını ID'ye göre getirir.
		/// </summary>
		/// <param name="id">Masraf ID</param>
		/// <returns>Masraf detayı</returns>
		[HttpGet("{id:long}")]
		public async Task<IActionResult> GetById(long id)
		{
			var result = await Mediator.Send(new GetExpenseByIdQuery(id));
			return Ok(result);
		}

		/// <summary>
		/// Yeni bir masraf kaydı oluşturur.
		/// </summary>
		/// <param name="request">Yeni masraf bilgileri</param>
		/// <returns>Oluşturulan masraf</returns>
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateExpenseRequest request)
		{
			var result = await Mediator.Send(new CreateExpenseCommand(request));
			return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
		}

		/// <summary>
		/// Mevcut bir masraf kaydını günceller.
		/// </summary>
		/// <param name="id">Masraf ID</param>
		/// <param name="request">Yeni masraf bilgileri</param>
		/// <returns>Güncellenmiş masraf</returns>
		[HttpPut("{id:long}")]
		public async Task<IActionResult> Update(long id, [FromBody] UpdateExpenseRequest request)
		{
			var result = await Mediator.Send(new UpdateExpenseCommand(id, request));
			return Ok(result);
		}

		/// <summary>
		/// Belirli bir masraf kaydını siler.
		/// </summary>
		/// <param name="id">Masraf ID</param>
		[HttpDelete("{id:long}")]
		public async Task<IActionResult> Delete(long id)
		{
			await Mediator.Send(new DeleteExpenseCommand(id));
			return NoContent();
		}
	}
}
