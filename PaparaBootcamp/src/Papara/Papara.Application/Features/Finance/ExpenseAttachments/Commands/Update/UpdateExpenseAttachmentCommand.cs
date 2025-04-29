using MediatR;
using Microsoft.AspNetCore.Http;
using Papara.Application.Features.Finance.ExpenseAttachments.Models;

namespace Papara.Application.Features.Finance.ExpenseAttachments.Commands.Update
{
	public class UpdateExpenseAttachmentCommand : IRequest<ExpenseAttachmentResponse>
	{
		public long Id { get; set; }
		public UpdateExpenseAttachmentRequest Request { get; set; }

		public UpdateExpenseAttachmentCommand(long id, UpdateExpenseAttachmentRequest request)
		{
			Id = id;
			Request = request;
		}
	}
}
