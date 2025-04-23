using Expense.Application.Features.EmployeeAddresses.Models;
using MediatR;

namespace Expense.Application.Features.EmployeeAddresses.Queries.GetAll;

public class GetAllEmployeeAddressesQuery : IRequest<List<EmployeeAddressResponse>>
{
	public GetEmployeeAddressRequest Request { get; set; }
	public GetAllEmployeeAddressesQuery(GetEmployeeAddressRequest request)
	{
		Request = request;
	}
}
