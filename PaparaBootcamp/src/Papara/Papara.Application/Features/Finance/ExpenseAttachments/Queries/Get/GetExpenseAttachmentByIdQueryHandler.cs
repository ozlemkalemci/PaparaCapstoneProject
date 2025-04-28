using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.Finance.ExpenseAttachments.Converters;
using Papara.Application.Features.Finance.ExpenseAttachments.Models;
using Papara.Domain.Entities.Finance;
using System.Linq.Expressions;

namespace Papara.Application.Features.Finance.ExpenseAttachments.Queries.Get
{
	public class GetExpenseAttachmentByIdQueryHandler : IRequestHandler<GetExpenseAttachmentByIdQuery, ExpenseAttachmentResponse>
	{
		private readonly IUnitOfWork _unitOfWork;

		public GetExpenseAttachmentByIdQueryHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<ExpenseAttachmentResponse> Handle(GetExpenseAttachmentByIdQuery request, CancellationToken cancellationToken)
		{
			var includes = new List<Expression<Func<ExpenseAttachment, object>>>
			{
				x => x.Expense
			};

			var entity = await _unitOfWork.Repository<ExpenseAttachment>().GetByIdAsync(request.Id, includes.ToArray());

			if (entity == null)
				throw new KeyNotFoundException("Dosya kaydı bulunamadı.");

			return ExpenseAttachmentConverters.ExpenseAttachmentConverter(entity);
		}
	}
}
