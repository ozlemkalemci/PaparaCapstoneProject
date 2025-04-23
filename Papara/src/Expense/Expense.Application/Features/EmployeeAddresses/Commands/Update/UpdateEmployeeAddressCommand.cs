using Expense.Application.Features.EmployeeAddresses.Models;
using MediatR;

namespace Expense.Application.Features.EmployeeAddresses.Commands.Update;

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