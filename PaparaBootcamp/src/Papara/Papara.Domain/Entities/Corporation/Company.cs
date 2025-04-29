using Base.Domain.Entities;

namespace Papara.Domain.Entities.Corporation;

public class Company : BaseEntity
{
	public string CompanyName { get; set; } = string.Empty;
	public string TaxNumber { get; set; } = string.Empty;
	public string CompanyIBAN { get; set; } = string.Empty;
}
