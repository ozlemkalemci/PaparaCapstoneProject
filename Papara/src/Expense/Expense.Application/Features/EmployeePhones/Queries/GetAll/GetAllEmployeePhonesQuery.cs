using Expense.Application.Features.EmployeePhones.Models;
using MediatR;

namespace Expense.Application.Features.EmployeePhones.Queries.GetAll;

public class GetAllEmployeePhonesQuery : IRequest<List<EmployeePhoneResponse>>
{
	public GetEmployeePhoneRequest Request { get; set; }

	public GetAllEmployeePhonesQuery(GetEmployeePhoneRequest request)
	{
		Request = request;
	}
}