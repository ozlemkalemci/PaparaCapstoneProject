using MediatR;
using Papara.Application.Features.Finance.ExpenseTypes.Models;

namespace Papara.Application.Features.Finance.ExpenseTypes.Commands.Update;

public class UpdateExpenseTypeCommand : IRequest<ExpenseTypeResponse>
{
	public long Id { get; set; }
	public UpdateExpenseTypeRequest Request { get; set; }

	public UpdateExpenseTypeCommand(long id, UpdateExpenseTypeRequest request)
	{
		Id = id;
		Request = request;
	}
}
