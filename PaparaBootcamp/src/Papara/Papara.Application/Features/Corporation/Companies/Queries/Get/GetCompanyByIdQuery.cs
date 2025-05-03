using MediatR;
using Papara.Application.Features.Corporation.Companies.Models;

namespace Papara.Application.Features.Corporation.Companies.Queries.Get;

public class GetCompanyByIdQuery : IRequest<CompanyResponse>
{
	public long Id { get; set; }

	public GetCompanyByIdQuery(long id)
	{
		Id = id;
	}
}
