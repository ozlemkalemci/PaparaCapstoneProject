using Base.Application.Common.Extensions;
using Base.Domain.Interfaces;
using MediatR;
using System.Linq.Expressions;
using Papara.Application.Features.Finance.Expenses.Converters;
using Papara.Application.Features.Finance.Expenses.Models;
using Papara.Domain.Entities.Finance;
using Base.Application.Interfaces;
using Base.Domain.Enums;

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
		var filter = (Expression<Func<Expense, bool>>)(x => x.IsActive);
		var includes = new List<Expression<Func<Expense, object>>>();

		var currentUserId = _userContextService.GetCurrentUserId();
		var currentUserRole = _userContextService.GetCurrentUserRole();

		if (currentUserId > 0 && currentUserRole == UserRole.Employee.GetDisplayName())
		{
			// Eğer Personel başka birinin EmployeeId'sini göndermeye çalışıyorsa izin verme
			if (request.Request.EmployeeId.HasValue && request.Request.EmployeeId != currentUserId)
				throw new UnauthorizedAccessException("Başka bir çalışanın masraf kayıtlarına erişemezsiniz.");

			// Personel sadece kendi masraflarını görebilir
			filter = filter.And(x => x.EmployeeId == currentUserId);
		}

		if (request.Request.EmployeeId.HasValue)
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
