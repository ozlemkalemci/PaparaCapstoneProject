using Expense.Application.Features.EmployeeAddresses.Models;
using Expense.Application.Features.Employees.Converters;
using Expense.Domain.Entities;

namespace Expense.Application.Features.EmployeeAddresses.Converters;

public static class EmployeeAddressConverters
{
	public static EmployeeAddressResponse EmployeeAddressConverter(EmployeeAddress item)
	{
		return new EmployeeAddressResponse
		{
			Id = item.Id,
			EmployeeId = item.EmployeeId,
			City = item.City,
			Detail = item.Detail,
			District = item.District,

			ResponseEmployee = item.Employee == null ? null : EmployeeConverters.EmployeeConverter(item.Employee)
		};
	}

	public static List<EmployeeAddressResponse> EmployeeAddressConverterList(List<EmployeeAddress> items)
	{
		if (items == null || items.Count == 0)
			return new List<EmployeeAddressResponse>();

		var responseDto = (from item in items select EmployeeAddressConverter(item)).ToList();

		return responseDto;
	}
}