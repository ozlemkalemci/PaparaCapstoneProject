using Papara.Application.Features.Finance.Expenses.Models;
using Papara.Application.Features.HR.Employees.Converters;
using Papara.Application.Features.Finance.ExpenseTypes.Converters;
using Papara.Domain.Entities.Finance;

namespace Papara.Application.Features.Finance.Expenses.Converters;

public static class ExpenseConverters
{
	public static ExpenseResponse ExpenseConverter(Expense item)
	{
		return new ExpenseResponse
		{
			Id = item.Id,
			EmployeeId = item.EmployeeId,
			Amount = item.Amount,
			Description = item.Description,
			ExpenseDate = item.ExpenseDate,
			ExpenseTypeId = item.ExpenseTypeId,
			Concluded = item.Concluded,

			ResponseEmployee = item.Employee == null ? null :
				EmployeeConverters.EmployeeConverter(item.Employee),

			ResponseExpenseType = item.ExpenseType == null ? null :
				ExpenseTypeConverters.ExpenseTypeConverter(item.ExpenseType),

		
		};
	}

	public static List<ExpenseResponse> ExpenseConverterList(List<Expense> items)
	{
		if (items == null || items.Count == 0)
			return new List<ExpenseResponse>();

		var responseDto = (from item in items select ExpenseConverter(item)).ToList();
		return responseDto;
	}
}
