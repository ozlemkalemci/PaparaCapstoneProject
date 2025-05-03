using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papara.Application.Features.Corporation.Companies.Models;

public class CompanyResponse
{
	public long Id { get; set; }
	public string CompanyName { get; set; }
	public string TaxNumber { get; set; }
	public string CompanyIBAN { get; set; }
}
