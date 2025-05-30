﻿using Base.Application.Common.Extensions;
using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.Finance.ExpenseApprovals.Converters;
using Papara.Application.Features.Finance.ExpenseApprovals.Models;
using Papara.Domain.Entities.Finance;
using Papara.Domain.Enums.Finance;
using System.Linq.Expressions;

namespace Papara.Application.Features.Finance.ExpenseApprovals.Queries.GetAll;

public class GetAllExpenseApprovalsQueryHandler : IRequestHandler<GetAllExpenseApprovalsQuery, List<ExpenseApprovalResponse>>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserContextService _userContextService;

	public GetAllExpenseApprovalsQueryHandler(IUnitOfWork unitOfWork, IUserContextService userContextService)
	{
		_unitOfWork = unitOfWork;
		_userContextService = userContextService;
	}

	public async Task<List<ExpenseApprovalResponse>> Handle(GetAllExpenseApprovalsQuery request, CancellationToken cancellationToken)
	{
		var filter = (Expression<Func<ExpenseApproval, bool>>)(x => x.IsActive);
		var includes = new List<Expression<Func<ExpenseApproval, object>>>();
		var currentUserRole = _userContextService.GetCurrentUserRole();

		if ((request.Request.EmployeeId == null || request.Request.EmployeeId == 0) && currentUserRole == "Employee")
		{
			filter = filter.And(x => x.Expense.EmployeeId == _userContextService.GetCurrentEmployeeId());
		}
		if (request.Request.ExpenseId > 0)
		{
			filter = filter.And(x => x.ExpenseId == request.Request.ExpenseId);
		}
		if (request.Request.Status.HasValue && !Enum.IsDefined(typeof(ExpenseApprovalStatus), request.Request.Status.Value))
			throw new InvalidOperationException("Geçersiz onay durumu girildi.");

		if (request.Request.Status.HasValue)
		{
			filter = filter.And(x => x.Status == request.Request.Status);
		}

		if (request.Request.IncludeExpense)
		{
			includes.Add(x => x.Expense);
		}

		var entities = await _unitOfWork.Repository<ExpenseApproval>()
			.GetAllAsync(filter, includes.ToArray());

		return ExpenseApprovalConverters.ExpenseApprovalConverterList(entities);
	}
}
