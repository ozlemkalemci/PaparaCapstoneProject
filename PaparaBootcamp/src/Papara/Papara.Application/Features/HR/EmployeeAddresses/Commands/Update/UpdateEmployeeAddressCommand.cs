using MediatR;
using Papara.Application.Features.HR.EmployeeAddresses.Models;

namespace Papara.Application.Features.HR.EmployeeAddresses.Commands.Update;

public class UpdateEmployeeAddressCommand : IRequest<EmployeeAddressResponse>
{
	public long Id { get; set; }
	public UpdateEmployeeAddressRequest Request { get; set; }

	public UpdateEmployeeAddressCommand(long id, UpdateEmployeeAddressRequest request)
	{
		Id = id;
		Request = request;
	}
}