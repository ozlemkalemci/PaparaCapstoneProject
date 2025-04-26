using MediatR;
using Papara.Application.Features.Finance.Expenses.Models;

namespace Papara.Application.Features.Finance.Expenses.Commands.Create;

public class CreateExpenseCommand : IRequest<ExpenseResponse>
{
	public CreateExpenseRequest Request { get; set; }

	public CreateExpenseCommand(CreateExpenseRequest request)
	{
		Request = request;
	}
}
