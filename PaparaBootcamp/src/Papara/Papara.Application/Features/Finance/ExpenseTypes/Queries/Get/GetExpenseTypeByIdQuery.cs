using MediatR;
using Papara.Application.Features.Finance.ExpenseTypes.Models;

namespace Papara.Application.Features.Finance.ExpenseTypes.Queries.Get;

public class GetExpenseTypeByIdQuery : IRequest<ExpenseTypeResponse>
{
	public long Id { get; set; }

	public GetExpenseTypeByIdQuery(long id)
	{
		Id = id;
	}
}
