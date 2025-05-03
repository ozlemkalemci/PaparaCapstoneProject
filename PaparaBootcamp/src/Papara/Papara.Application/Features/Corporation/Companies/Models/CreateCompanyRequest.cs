namespace Papara.Application.Features.Corporation.Companies.Models;

public class CreateCompanyRequest
{
	public string CompanyName { get; set; }
	public string TaxNumber { get; set; }
	public string CompanyIBAN { get; set; }
}
