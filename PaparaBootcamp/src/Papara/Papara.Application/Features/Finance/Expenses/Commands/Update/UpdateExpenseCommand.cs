using MediatR;
using Papara.Application.Features.Finance.Expenses.Models;

namespace Papara.Application.Features.Finance.Expenses.Commands.Update;

public class UpdateExpenseCommand : IRequest<ExpenseResponse>
{
	public long Id { get; set; }
	public UpdateExpenseRequest Request { get; set; }

	public UpdateExpenseCommand(long id, UpdateExpenseRequest request)
	{
		Id = id;
		Request = request;
	}
}
