using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.Finance.ExpenseApprovals.Converters;
using Papara.Application.Features.Finance.ExpenseApprovals.Models;
using Papara.Domain.Entities.Finance;
using System.Linq.Expressions;

namespace Papara.Application.Features.Finance.ExpenseApprovals.Queries.Get;

public class GetExpenseApprovalByIdQueryHandler : IRequestHandler<GetExpenseApprovalByIdQuery, ExpenseApprovalResponse>
{
	private readonly IUnitOfWork _unitOfWork;

	public GetExpenseApprovalByIdQueryHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<ExpenseApprovalResponse> Handle(GetExpenseApprovalByIdQuery request, CancellationToken cancellationToken)
	{
		var includes = new List<Expression<Func<ExpenseApproval, object>>>
		{
			x => x.Expense,
		};

		var entity = await _unitOfWork.Repository<ExpenseApproval>().GetByIdAsync(request.Id, includes.ToArray());

		if (entity == null)
			throw new KeyNotFoundException("Onay kaydı bulunamadı.");

		return ExpenseApprovalConverters.ExpenseApprovalConverter(entity);
	}
}
