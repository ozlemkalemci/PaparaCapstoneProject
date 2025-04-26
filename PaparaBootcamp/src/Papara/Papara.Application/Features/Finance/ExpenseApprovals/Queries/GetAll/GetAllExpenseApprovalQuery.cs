using MediatR;
using Papara.Application.Features.Finance.ExpenseApprovals.Models;

namespace Papara.Application.Features.Finance.ExpenseApprovals.Queries.GetAll;

public class GetAllExpenseApprovalsQuery : IRequest<List<ExpenseApprovalResponse>>
{
	public GetExpenseApprovalRequest Request { get; set; }

	public GetAllExpenseApprovalsQuery(GetExpenseApprovalRequest request)
	{
		Request = request;
	}
}
