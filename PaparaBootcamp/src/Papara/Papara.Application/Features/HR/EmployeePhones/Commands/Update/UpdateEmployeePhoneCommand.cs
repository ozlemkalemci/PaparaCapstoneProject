using MediatR;
using Papara.Application.Features.HR.EmployeePhones.Models;

namespace Papara.Application.Features.HR.EmployeePhones.Commands.Update;

public class UpdateEmployeePhoneCommand : IRequest<EmployeePhoneResponse>
{
	public long Id { get; set; }
	public UpdateEmployeePhoneRequest Request { get; set; }

	public UpdateEmployeePhoneCommand(long id, UpdateEmployeePhoneRequest request)
	{
		Id = id;
		Request = request;
	}
}