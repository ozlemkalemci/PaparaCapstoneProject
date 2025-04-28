using MediatR;
using Papara.Application.Features.Finance.ExpenseAttachments.Models;

namespace Papara.Application.Features.Finance.ExpenseAttachments.Queries.GetAll
{
	public class GetAllExpenseAttachmentsQuery : IRequest<List<ExpenseAttachmentResponse>>
	{
		public GetExpenseAttachmentRequest Request { get; set; }

		public GetAllExpenseAttachmentsQuery(GetExpenseAttachmentRequest request)
		{
			Request = request;
		}
	}
}
