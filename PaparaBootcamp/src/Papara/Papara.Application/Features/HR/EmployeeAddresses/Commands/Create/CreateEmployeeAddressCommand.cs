using MediatR;
using Papara.Application.Features.HR.EmployeeAddresses.Models;

namespace Papara.Application.Features.HR.EmployeeAddresses.Commands.Create;

public class CreateEmployeeAddressCommand : IRequest<EmployeeAddressResponse>
{
	public CreateEmployeeAddressRequest Request { get; set; }

	public CreateEmployeeAddressCommand(CreateEmployeeAddressRequest request)
	{
		Request = request;
	}
}