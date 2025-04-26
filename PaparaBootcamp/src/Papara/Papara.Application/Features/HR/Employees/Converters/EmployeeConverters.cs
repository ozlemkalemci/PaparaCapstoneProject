using Papara.Application.Features.Corporation.Departments.Converters;
using Papara.Application.Features.HR.EmployeeAddresses.Converters;
using Papara.Application.Features.HR.Employees.Models;
using Papara.Application.Features.HR.EmployeePhones.Converters;
using Papara.Domain.Entities.HR;

namespace Papara.Application.Features.HR.Employees.Converters;

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
			IdentityNumber = item.IdentityNumber,
			IBAN = item.IBAN,
			DepartmentId = item.DepartmentId,
			UserId = item.UserId,

			ResponseDepartment = item.Department == null ? null :
				DepartmentConverters.DepartmentConverter(item.Department),
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