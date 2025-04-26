using Papara.Application.Features.Finance.ExpenseApprovals.Models;
using Papara.Application.Features.Finance.Expenses.Converters;
using Papara.Domain.Entities.Finance;

namespace Papara.Application.Features.Finance.ExpenseApprovals.Converters;

public static class ExpenseApprovalConverters
{
	public static ExpenseApprovalResponse ExpenseApprovalConverter(ExpenseApproval item)
	{
		return new ExpenseApprovalResponse
		{
			Id = item.Id,
			ExpenseId = item.ExpenseId,
			Status = item.Status,
			Description = item.Description,
			ApprovedById = item.ApprovedById,
			ApprovedDate = item.ApprovedDate,
			
			ResponseExpense = item.Expense == null ? null :
				ExpenseConverters.ExpenseConverter(item.Expense),
		};
	}

	public static List<ExpenseApprovalResponse> ExpenseApprovalConverterList(List<ExpenseApproval> items)
	{
		if (items == null || items.Count == 0)
			return new List<ExpenseApprovalResponse>();

		var responseDto = (from item in items select ExpenseApprovalConverter(item)).ToList();

		return responseDto;
	}
}