using Papara.Application.Features.Finance.ExpenseTypes.Models;
using Papara.Domain.Entities.Finance;

namespace Papara.Application.Features.Finance.ExpenseTypes.Converters;

public static class ExpenseTypeConverters
{
	public static ExpenseTypeResponse ExpenseTypeConverter(ExpenseType item)
	{
		return new ExpenseTypeResponse
		{
			Id = item.Id,
			Name = item.Name,
			Description = item.Description
		};
	}

	public static List<ExpenseTypeResponse> ExpenseTypeConverterList(List<ExpenseType> items)
	{
		if (items == null || items.Count == 0)
			return new List<ExpenseTypeResponse>();

		var responseDto = (from item in items select ExpenseTypeConverter(item)).ToList();
		return responseDto;
	}
}
