using Expense.Application.Features.EmployeeDepartments.Models;
using Expense.Domain.Entities;

namespace Expense.Application.Features.EmployeeDepartments.Converters;

public static class EmployeeDepartmentConverters
{
	public static EmployeeDepartmentResponse EmployeeDepartmentConverter(EmployeeDepartment item)
	{
		return new EmployeeDepartmentResponse
		{
			Id = item.Id,
			DepartmentName = item.DepartmentName,
		};
	}

	public static List<EmployeeDepartmentResponse> EmployeeDepartmentConverterList(List<EmployeeDepartment> items)
	{
		if (items == null || items.Count == 0)
			return new List<EmployeeDepartmentResponse>();

		var responseDto = (from item in items select EmployeeDepartmentConverter(item)).ToList();

		return responseDto;
	}
}