using MediatR;

namespace Papara.Application.Features.Finance.ExpenseAttachments.Commands.Delete
{
	public class DeleteExpenseAttachmentCommand : IRequest<Unit>
	{
		public long Id { get; }

		public DeleteExpenseAttachmentCommand(long id)
		{
			Id = id;
		}
	}
}
