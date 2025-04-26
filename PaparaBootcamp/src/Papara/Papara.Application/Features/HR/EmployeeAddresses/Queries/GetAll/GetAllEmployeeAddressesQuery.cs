using MediatR;
using Papara.Application.Features.HR.EmployeeAddresses.Models;

namespace Papara.Application.Features.HR.EmployeeAddresses.Queries.GetAll;

public class GetAllEmployeeAddressesQuery : IRequest<List<EmployeeAddressResponse>>
{
	public GetEmployeeAddressRequest Request { get; set; }
	public GetAllEmployeeAddressesQuery(GetEmployeeAddressRequest request)
	{
		Request = request;
	}
}
