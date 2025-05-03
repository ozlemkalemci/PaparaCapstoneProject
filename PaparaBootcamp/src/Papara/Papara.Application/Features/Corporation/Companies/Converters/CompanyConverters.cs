using Papara.Application.Features.Corporation.Companies.Models;
using Papara.Domain.Entities.Corporation;

namespace Papara.Application.Features.Corporation.Companies.Converters;

public class CompanyConverters
{
	public static CompanyResponse CompanyConverter(Company item)
	{
		return new CompanyResponse
		{
			Id = item.Id,
			CompanyName = item.CompanyName,
			CompanyIBAN = item.CompanyIBAN,
			TaxNumber = item.TaxNumber
		};
	}

	public static List<CompanyResponse> CompanyConverterList(List<Company> items)
	{
		if (items == null || items.Count == 0)
			return new List<CompanyResponse>();

		var responseDto = (from item in items select CompanyConverter(item)).ToList();

		return responseDto;
	}
}
