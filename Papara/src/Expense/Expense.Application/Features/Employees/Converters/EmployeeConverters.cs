using Expense.Application.Features.Employees.Models;
using Expense.Domain.Entities;

namespace Expense.Application.Features.Employees.Converters;

public static class EmployeeConverters
{
	public static EmployeeResponseDto EmployeeConverter(Employee item)
	{
		return new EmployeeResponseDto
		{
			Id = item.Id,
			FirstName = item.FirstName,
			MiddleName = item.MiddleName,
			LastName = item.LastName,
			Email = item.Email,
			IdentityNumber = item.IdentityNumber,
			IBAN = item.IBAN,
			DepartmentId = item.DepartmentId,
			UserId = item.UserId
		};
	}

	public static List<EmployeeResponseDto> EmployeeConverterList(List<Employee> items)
	{
		if (items == null || items.Count == 0)
			return new List<EmployeeResponseDto>();

		var responseDto = (from item in items select EmployeeConverter(item)).ToList();

		return responseDto;
	}
}