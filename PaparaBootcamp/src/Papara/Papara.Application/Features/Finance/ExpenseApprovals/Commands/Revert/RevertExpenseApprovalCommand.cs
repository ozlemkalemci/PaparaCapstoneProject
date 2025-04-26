using MediatR;
using Papara.Application.Features.Finance.ExpenseApprovals.Models;

namespace Papara.Application.Features.Finance.ExpenseApprovals.Commands.Revert;

public class RevertExpenseApprovalCommand : IRequest<ExpenseApprovalResponse>
{
	public long Id { get; set; }
	public string? Description { get; set; }

	public RevertExpenseApprovalCommand(long id, string? description)
	{
		Id = id;
		Description = description;
	}
}
