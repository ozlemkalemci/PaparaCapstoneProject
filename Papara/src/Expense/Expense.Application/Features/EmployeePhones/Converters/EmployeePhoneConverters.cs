using Expense.Application.Features.EmployeePhones.Models;
using Expense.Application.Features.Employees.Converters;
using Expense.Domain.Entities;

namespace Expense.Application.Features.EmployeePhones.Converters;

public static class EmployeePhoneConverters
{
	public static EmployeePhoneResponse EmployeePhoneConverter(EmployeePhone item)
	{
		return new EmployeePhoneResponse
		{
			Id = item.Id,
			EmployeeId = item.EmployeeId,
			IsPrimary = item.IsPrimary,
			PhoneNumber = item.PhoneNumber,
			Type = item.Type,

			ResponseEmployee = item.Employee == null ? null : EmployeeConverters.EmployeeConverter(item.Employee)
		};
	}

	public static List<EmployeePhoneResponse> EmployeePhoneConverterList(List<EmployeePhone> items)
	{
		if (items == null || items.Count == 0)
			return new List<EmployeePhoneResponse>();

		var responseDto = (from item in items select EmployeePhoneConverter(item)).ToList();

		return responseDto;
	}
}