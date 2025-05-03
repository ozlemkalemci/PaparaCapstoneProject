using MediatR;

namespace Papara.Application.Features.Corporation.Companies.Commands.Delete;

public class DeleteCompanyCommand : IRequest<Unit>
{
	public long Id { get; }
	public DeleteCompanyCommand(long id)
	{
		Id = id;
	}
}
