using MediatR;
using Papara.Application.Features.Finance.ExpenseAttachments.Models;

namespace Papara.Application.Features.Finance.ExpenseAttachments.Queries.Get
{
	public class GetExpenseAttachmentByIdQuery : IRequest<ExpenseAttachmentResponse>
	{
		public long Id { get; set; }

		public GetExpenseAttachmentByIdQuery(long id)
		{
			Id = id;
		}
	}
}
