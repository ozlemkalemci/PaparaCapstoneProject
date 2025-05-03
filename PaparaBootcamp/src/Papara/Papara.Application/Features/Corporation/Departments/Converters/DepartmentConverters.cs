using Papara.Application.Features.Corporation.Departments.Models;
using Papara.Domain.Entities.Corporation;

namespace Papara.Application.Features.Corporation.Departments.Converters;

public static class DepartmentConverters
{
	public static DepartmentResponse DepartmentConverter(Department item)
	{
		return new DepartmentResponse
		{
			Id = item.Id,
			DepartmentName = item.DepartmentName,
		};
	}

	public static List<DepartmentResponse> DepartmentConverterList(List<Department> items)
	{
		if (items == null || items.Count == 0)
			return new List<DepartmentResponse>();

		var responseDto = (from item in items select DepartmentConverter(item)).ToList();

		return responseDto;
	}
}