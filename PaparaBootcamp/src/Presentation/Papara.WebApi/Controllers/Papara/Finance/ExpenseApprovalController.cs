using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Papara.WebApi.Controllers.Base;
using Papara.Application.Features.Finance.ExpenseApprovals.Models;
using Papara.Application.Features.Finance.ExpenseApprovals.Commands.Create;
using Papara.Application.Features.Finance.ExpenseApprovals.Commands.Revert;
using Papara.Application.Features.Finance.ExpenseApprovals.Queries.Get;
using Papara.Application.Features.Finance.ExpenseApprovals.Queries.GetAll;
using MediatR;
using Papara.Application.Services.Approvals;
using Papara.Application.Services.Banking.Models;
using Papara.Application.Services.Banking;
using Papara.Application.Services.Finance.Approvals;

namespace Papara.WebApi.Controllers.Papara.Finance
{
	[ApiController]
	[Route("api/expense-approvals")]
	[Authorize(Roles = "Admin")]
	public class ExpenseApprovalController : ApiControllerBase
	{
		private readonly IExpenseApprovalService _expenseApprovalService;
		private readonly IBankTransferSimulatorService _bankTransferService;

		public ExpenseApprovalController(
			IExpenseApprovalService expenseApprovalService,
			IBankTransferSimulatorService bankTransferService)
		{
			_expenseApprovalService = expenseApprovalService;
			_bankTransferService = bankTransferService;
		}

		/// <summary>
		/// Tüm masraf onaylarını filtreli olarak listeler.
		/// </summary>
		[HttpGet]
		
		public async Task<IActionResult> GetAll([FromQuery] GetExpenseApprovalRequest request)
		{
			var result = await Mediator.Send(new GetAllExpenseApprovalsQuery(request));
			return Ok(result);
		}

		/// <summary>
		/// Belirli bir masraf onay kaydını getirir.
		/// </summary>
		[HttpGet("{id:long}")]
		public async Task<IActionResult> GetById(long id)
		{
			var result = await Mediator.Send(new GetExpenseApprovalByIdQuery(id));
			return Ok(result);
		}

		/// <summary>
		/// Yalnızca onaylama işlemi yapar. Para transferi gerçekleştirmez.
		/// </summary>
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateExpenseApprovalRequest request)
		{
			var result = await Mediator.Send(new CreateExpenseApprovalCommand(request));
			return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
		}

		/// <summary>
		/// Onaylanmış bir masraf kaydını geri çeker
		/// </summary>
		[HttpPost("revert/{id:long}")]
		public async Task<IActionResult> Revert(long id, [FromBody] string? description)
		{
			var result = await Mediator.Send(new RevertExpenseApprovalCommand(id, description));
			return Ok(result);
		}

		/// <summary>
		/// Masrafı onaylar ve eş zamanlı olarak tanımlı IBAN'lara para transferini gerçekleştirir.
		/// </summary>
		[HttpPost("approve-and-transfer")]
		public async Task<IActionResult> CreateAndTransfer([FromBody] CreateAndTransferApprovalRequest request)
		{
			var result = await _expenseApprovalService.CreateAndTransferApprovalAsync(request);
			return Ok(result);
		}

		/// <summary>
		/// Daha önce onaylanmış bir masraf için manuel olarak yalnızca ödeme işlemini başlatır.
		/// </summary>
		[HttpPost("transfer")]
		public async Task<IActionResult> TransferOnly([FromBody] BankTransferRequest request)
		{
			var result = await _bankTransferService.TransferAsync(request);
			return Ok(result);
		}
	}
}
