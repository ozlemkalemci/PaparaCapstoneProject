using Expense.Application.Features.EmployeePhones.Models;
using MediatR;

namespace Expense.Application.Features.EmployeePhones.Commands.Update;

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