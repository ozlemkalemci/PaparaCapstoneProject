using MediatR;
using Papara.Application.Features.HR.EmployeePhones.Models;

namespace Papara.Application.Features.HR.EmployeePhones.Queries.Get;

public class GetEmployeePhoneByIdQuery : IRequest<EmployeePhoneResponse>
{
	public long Id { get; set; }

	public GetEmployeePhoneByIdQuery(long id)
	{
		Id = id;
	}
}