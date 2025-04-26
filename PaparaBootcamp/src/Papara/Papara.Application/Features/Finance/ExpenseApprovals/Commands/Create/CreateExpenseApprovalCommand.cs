using MediatR;
using Papara.Application.Features.Finance.ExpenseApprovals.Models;

namespace Papara.Application.Features.Finance.ExpenseApprovals.Commands.Create;

public class CreateExpenseApprovalCommand : IRequest<ExpenseApprovalResponse>
{
	public CreateExpenseApprovalRequest Request { get; set; }

	public CreateExpenseApprovalCommand(CreateExpenseApprovalRequest request)
	{
		Request = request;
	}
}
