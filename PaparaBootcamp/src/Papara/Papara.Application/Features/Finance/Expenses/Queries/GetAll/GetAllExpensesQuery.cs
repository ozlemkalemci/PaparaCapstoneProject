using MediatR;
using Papara.Application.Features.Finance.Expenses.Models;

namespace Papara.Application.Features.Finance.Expenses.Queries.GetAll;

public class GetAllExpensesQuery : IRequest<List<ExpenseResponse>>
{
	public GetExpenseRequest Request { get; set; }

	public GetAllExpensesQuery(GetExpenseRequest request)
	{
		Request = request;
	}
}
