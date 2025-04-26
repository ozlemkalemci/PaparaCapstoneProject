using MediatR;
using Papara.Application.Features.HR.EmployeeAddresses.Models;

namespace Papara.Application.Features.HR.EmployeeAddresses.Queries.Get;

public class GetEmployeeAddressByIdQuery : IRequest<EmployeeAddressResponse>
{
	public long Id { get; set; }

	public GetEmployeeAddressByIdQuery(long id)
	{
		Id = id;
	}
}