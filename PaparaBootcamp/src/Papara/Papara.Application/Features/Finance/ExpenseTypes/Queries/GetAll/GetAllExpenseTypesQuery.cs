using MediatR;
using Papara.Application.Features.Finance.ExpenseTypes.Models;
using System.Collections.Generic;

namespace Papara.Application.Features.Finance.ExpenseTypes.Queries.GetAll;

public class GetAllExpenseTypesQuery : IRequest<List<ExpenseTypeResponse>>
{
	public GetAllExpenseTypesQuery()
	{
	}
}
