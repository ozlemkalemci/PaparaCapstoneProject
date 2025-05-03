using MediatR;
using Papara.Application.Features.Corporation.Companies.Models;

namespace Papara.Application.Features.Corporation.Companies.Commands.Create;

public class CreateCompanyCommand : IRequest<CompanyResponse>
{
	public CreateCompanyRequest Request { get; set; }

	public CreateCompanyCommand(CreateCompanyRequest request)
	{
		Request = request;
	}
}

