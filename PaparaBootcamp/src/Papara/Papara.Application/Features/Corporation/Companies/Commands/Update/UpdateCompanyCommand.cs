using MediatR;
using Papara.Application.Features.Corporation.Companies.Models;

namespace Papara.Application.Features.Corporation.Companies.Commands.Update;

public class UpdateCompanyCommand : IRequest<CompanyResponse>
{
	public long Id { get; set; }
	public UpdateCompanyRequest Request { get; set; }
	public UpdateCompanyCommand(long id, UpdateCompanyRequest request)
	{
		Id = id;
		Request = request;
	}
}