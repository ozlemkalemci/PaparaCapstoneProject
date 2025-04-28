using Base.Application.Common.Extensions;
using Base.Domain.Interfaces;
using MediatR;
using System.Linq.Expressions;
using Papara.Application.Features.Finance.ExpenseAttachments.Converters;
using Papara.Application.Features.Finance.ExpenseAttachments.Models;
using Papara.Domain.Entities.Finance;

namespace Papara.Application.Features.Finance.ExpenseAttachments.Queries.GetAll
{
	public class GetAllExpenseAttachmentsQueryHandler : IRequestHandler<GetAllExpenseAttachmentsQuery, List<ExpenseAttachmentResponse>>
	{
		private readonly IUnitOfWork _unitOfWork;

		public GetAllExpenseAttachmentsQueryHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<List<ExpenseAttachmentResponse>> Handle(GetAllExpenseAttachmentsQuery request, CancellationToken cancellationToken)
		{
			var filter = (Expression<Func<ExpenseAttachment, bool>>)(x => x.IsActive);
			var includes = new List<Expression<Func<ExpenseAttachment, object>>>();

			if (request.Request.IncludeExpense)
			{
				includes.Add(x => x.Expense);
			}

			var entities = await _unitOfWork.Repository<ExpenseAttachment>()
				.GetAllAsync(filter, includes.ToArray());

			return ExpenseAttachmentConverters.ExpenseAttachmentConverterList(entities);
		}
	}
}
