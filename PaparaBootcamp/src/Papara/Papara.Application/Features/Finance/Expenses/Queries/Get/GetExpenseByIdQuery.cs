using MediatR;
using Papara.Application.Features.Finance.Expenses.Models;

namespace Papara.Application.Features.Finance.Expenses.Queries.Get;

public class GetExpenseByIdQuery : IRequest<ExpenseResponse>
{
	public long Id { get; set; }

	public GetExpenseByIdQuery(long id)
	{
		Id = id;
	}
}
