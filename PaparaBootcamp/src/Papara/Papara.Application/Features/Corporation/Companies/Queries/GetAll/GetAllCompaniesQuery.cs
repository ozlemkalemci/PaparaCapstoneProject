using MediatR;
using Papara.Application.Features.Corporation.Companies.Models;

namespace Papara.Application.Features.Corporation.Companies.Queries.GetAll;

public class GetAllCompaniesQuery : IRequest<List<CompanyResponse>>
{
	public GetCompanyRequest Request { get; set; }

	public GetAllCompaniesQuery(GetCompanyRequest request)
	{
		Request = request;
	}
}
