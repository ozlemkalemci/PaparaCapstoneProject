using MediatR;
using Papara.Application.Features.Finance.ExpenseApprovals.Models;

namespace Papara.Application.Features.Finance.ExpenseApprovals.Queries.Get;

public class GetExpenseApprovalByIdQuery : IRequest<ExpenseApprovalResponse>
{
	public long Id { get; set; }

	public GetExpenseApprovalByIdQuery(long id)
	{
		Id = id;
	}
}
