using Expense.Application.Features.EmployeeAddresses.Models;
using MediatR;

namespace Expense.Application.Features.EmployeeAddresses.Commands.Create;

public class CreateEmployeeAddressCommand : IRequest<EmployeeAddressResponse>
{
	public CreateEmployeeAddressRequest Request { get; set; }

	public CreateEmployeeAddressCommand(CreateEmployeeAddressRequest request)
	{
		Request = request;
	}
}