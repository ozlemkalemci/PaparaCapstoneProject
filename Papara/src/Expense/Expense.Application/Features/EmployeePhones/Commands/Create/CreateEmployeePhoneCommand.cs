using Expense.Application.Features.EmployeePhones.Models;
using MediatR;

namespace Expense.Application.Features.EmployeePhones.Commands.Create;

public class CreateEmployeePhoneCommand : IRequest<EmployeePhoneResponse>
{
	public CreateEmployeePhoneRequest Request { get; set; }

	public CreateEmployeePhoneCommand(CreateEmployeePhoneRequest request)
	{
		Request = request;
	}
}