using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.Finance.ExpenseTypes.Converters;
using Papara.Application.Features.Finance.ExpenseTypes.Models;
using Papara.Domain.Entities.Finance;

namespace Papara.Application.Features.Finance.ExpenseTypes.Queries.Get;

public class GetExpenseTypeByIdQueryHandler : IRequestHandler<GetExpenseTypeByIdQuery, ExpenseTypeResponse>
{
	private readonly IUnitOfWork _unitOfWork;

	public GetExpenseTypeByIdQueryHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<ExpenseTypeResponse> Handle(GetExpenseTypeByIdQuery request, CancellationToken cancellationToken)
	{
		var expenseType = await _unitOfWork.Repository<ExpenseType>().GetByIdAsync(request.Id);

		if (expenseType == null)
			throw new KeyNotFoundException("Masraf kategorisi bulunamadı.");

		return ExpenseTypeConverters.ExpenseTypeConverter(expenseType);
	}
}
