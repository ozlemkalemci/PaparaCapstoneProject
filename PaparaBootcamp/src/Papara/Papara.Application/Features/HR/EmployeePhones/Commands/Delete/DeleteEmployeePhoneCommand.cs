using MediatR;

namespace Papara.Application.Features.HR.EmployeePhones.Commands.Delete;

public class DeleteEmployeePhoneCommand : IRequest<Unit>
{
	public long Id { get; }

	public DeleteEmployeePhoneCommand(long id)
	{
		Id = id;
	}
}