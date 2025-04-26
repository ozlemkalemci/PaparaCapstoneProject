using Papara.Application.Features.HR.EmployeeAddresses.Models;
using Papara.Application.Features.HR.Employees.Converters;
using Papara.Domain.Entities.HR;

namespace Papara.Application.Features.HR.EmployeeAddresses.Converters;

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