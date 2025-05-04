using Base.Application.Common.Extensions;
using Base.Application.Common.Helpers;
using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.Finance.Expenses.Converters;
using Papara.Application.Features.Finance.Expenses.Models;
using Papara.Domain.Enums.Finance;
using System.Linq.Expressions;

namespace Papara.Application.Features.Finance.Expenses.Queries.GetAll;

public class GetAllExpensesQueryHandler : IRequestHandler<GetAllExpensesQuery, List<ExpenseResponse>>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserContextService _userContextService;
	public GetAllExpensesQueryHandler(IUnitOfWork unitOfWork, IUserContextService userContextService)
	{
		_unitOfWork = unitOfWork;
		_userContextService = userContextService;
	}

	public async Task<List<ExpenseResponse>> Handle(GetAllExpensesQuery request, CancellationToken cancellationToken)
	{
		var filter = (Expression<Func<Expense, bool>>)(x => x.IsActive && x.Concluded);
		var includes = new List<Expression<Func<Expense, object>>>();
		var currentUserRole = _userContextService.GetCurrentUserRole();

		if ((request.Request.EmployeeId == null || request.Request.EmployeeId == 0) && currentUserRole == "Employee")
		{
			filter = filter.And(x => x.EmployeeId == _userContextService.GetCurrentEmployeeId());
		}
		if (request.Request.EmployeeId > 0 && currentUserRole == "Employee")
		{
			AuthorizationHelper.EnsureEmployeeOwnsData(_userContextService, request.Request.EmployeeId.Value);
		}
		if (request.Request.EmployeeId > 0)
		{
			filter = filter.And(x => x.EmployeeId == request.Request.EmployeeId);
		}
		if (request.Request.ExpenseTypeId.HasValue)
		{
			filter = filter.And(x => x.ExpenseTypeId == request.Request.ExpenseTypeId);
		}
		if (request.Request.IncludeEmployee)
		{
			includes.Add(x => x.Employee);
		}
		if (request.Request.IncludeExpenseType)
		{
			includes.Add(x => x.ExpenseType);
		}

		var expenses = await _unitOfWork.Repository<Expense>()
			.GetAllAsync(filter, includes.ToArray());

		return ExpenseConverters.ExpenseConverterList(expenses);
	}
}
