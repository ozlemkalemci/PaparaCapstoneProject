using Expense.Application.Features.EmployeeAddresses.Models;
using MediatR;

namespace Expense.Application.Features.EmployeeAddresses.Queries.Get;

public class GetEmployeeAddressByIdQuery : IRequest<EmployeeAddressResponse>
{
	public long Id { get; set; }

	public GetEmployeeAddressByIdQuery(long id)
	{
		Id = id;
	}
}