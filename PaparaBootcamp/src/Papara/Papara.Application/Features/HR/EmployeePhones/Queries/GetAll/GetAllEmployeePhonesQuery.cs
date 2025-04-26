using MediatR;
using Papara.Application.Features.HR.EmployeePhones.Models;

namespace Papara.Application.Features.HR.EmployeePhones.Queries.GetAll;

public class GetAllEmployeePhonesQuery : IRequest<List<EmployeePhoneResponse>>
{
	public GetEmployeePhoneRequest Request { get; set; }

	public GetAllEmployeePhonesQuery(GetEmployeePhoneRequest request)
	{
		Request = request;
	}
}