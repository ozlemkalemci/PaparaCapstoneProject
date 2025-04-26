using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.Finance.ExpenseTypes.Converters;
using Papara.Application.Features.Finance.ExpenseTypes.Models;
using Papara.Domain.Entities.Finance;

namespace Papara.Application.Features.Finance.ExpenseTypes.Queries.GetAll;

public class GetAllExpenseTypesQueryHandler : IRequestHandler<GetAllExpenseTypesQuery, List<ExpenseTypeResponse>>
{
	private readonly IUnitOfWork _unitOfWork;

	public GetAllExpenseTypesQueryHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<List<ExpenseTypeResponse>> Handle(GetAllExpenseTypesQuery request, CancellationToken cancellationToken)
	{
		var expenseTypes = await _unitOfWork.Repository<ExpenseType>().GetAllAsync();

		return ExpenseTypeConverters.ExpenseTypeConverterList(expenseTypes);
	}
}
