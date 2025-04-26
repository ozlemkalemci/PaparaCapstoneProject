using MediatR;
using Papara.Application.Features.HR.EmployeePhones.Models;

namespace Papara.Application.Features.HR.EmployeePhones.Commands.Create;

public class CreateEmployeePhoneCommand : IRequest<EmployeePhoneResponse>
{
	public CreateEmployeePhoneRequest Request { get; set; }

	public CreateEmployeePhoneCommand(CreateEmployeePhoneRequest request)
	{
		Request = request;
	}
}