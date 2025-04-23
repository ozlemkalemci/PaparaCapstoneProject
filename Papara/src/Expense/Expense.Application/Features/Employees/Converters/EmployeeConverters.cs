using Expense.Application.Features.EmployeeAddresses.Converters;
using Expense.Application.Features.EmployeeDepartments.Converters;
using Expense.Application.Features.EmployeePhones.Converters;
using Expense.Application.Features.Employees.Models;
using Expense.Domain.Entities;

namespace Expense.Application.Features.Employees.Converters;

public static class EmployeeConverters
{
	public static EmployeeResponse EmployeeConverter(Employee item)
	{
		return new EmployeeResponse
		{
			Id = item.Id,
			FirstName = item.FirstName,
			MiddleName = item.MiddleName,
			LastName = item.LastName,
			Email = item.Email,
			IdentityNumber = item.IdentityNumber,
			IBAN = item.IBAN,
			DepartmentId = item.DepartmentId,
			UserId = item.UserId,

			ResponseDepartment = item.Department == null ? null :
				EmployeeDepartmentConverters.EmployeeDepartmentConverter(item.Department),

			ResponsePhones = item.Phones == null ? null :
				EmployeePhoneConverters.EmployeePhoneConverterList(item.Phones.ToList()),

			ResponseAddresses = item.Addresses == null ? null :
				EmployeeAddressConverters.EmployeeAddressConverterList(item.Addresses.ToList())
		};
	}

	public static List<EmployeeResponse> EmployeeConverterList(List<Employee> items)
	{
		if (items == null || items.Count == 0)
			return new List<EmployeeResponse>();

		var responseDto = (from item in items select EmployeeConverter(item)).ToList();

		return responseDto;
	}
}