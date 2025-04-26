using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.Finance.Expenses.Converters;
using Papara.Application.Features.Finance.Expenses.Models;
using System.Linq.Expressions;

namespace Papara.Application.Features.Finance.Expenses.Queries.Get;

public class GetExpenseByIdQueryHandler : IRequestHandler<GetExpenseByIdQuery, ExpenseResponse>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserContextService _userContextService;

	public GetExpenseByIdQueryHandler(IUnitOfWork unitOfWork, IUserContextService userContextService)
	{
		_unitOfWork = unitOfWork;
		_userContextService = userContextService;
	}

	public async Task<ExpenseResponse> Handle(GetExpenseByIdQuery request, CancellationToken cancellationToken)
	{
		var includes = new List<Expression<Func<Expense, object>>>
	{
		x => x.Employee,
		x => x.ExpenseType,
	};

		var entity = await _unitOfWork.Repository<Expense>()
			.GetByIdAsync(request.Id, includes.ToArray());

		if (entity == null)
			throw new KeyNotFoundException("Masraf kaydı bulunamadı.");

		var currentUserRole = _userContextService.GetCurrentUserRole();
		var currentUserId = _userContextService.GetCurrentUserId();

		// Eğer Employee ise ve başka birinin masrafına erişmeye çalışıyorsa erişim engelle
		if (currentUserRole == "Employee" && entity.EmployeeId != currentUserId)
			throw new UnauthorizedAccessException("Başka bir çalışanın masraf kaydına erişemezsiniz.");

		return ExpenseConverters.ExpenseConverter(entity);
	}

}
