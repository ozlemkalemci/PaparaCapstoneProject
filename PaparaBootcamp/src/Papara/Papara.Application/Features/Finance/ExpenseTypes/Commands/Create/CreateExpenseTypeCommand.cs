using MediatR;
using Papara.Application.Features.Finance.ExpenseTypes.Models;

namespace Papara.Application.Features.Finance.ExpenseTypes.Commands.Create;

public class CreateExpenseTypeCommand : IRequest<ExpenseTypeResponse>
{
	public CreateExpenseTypeRequest Request { get; set; }

	public CreateExpenseTypeCommand(CreateExpenseTypeRequest request)
	{
		Request = request;
	}
}
