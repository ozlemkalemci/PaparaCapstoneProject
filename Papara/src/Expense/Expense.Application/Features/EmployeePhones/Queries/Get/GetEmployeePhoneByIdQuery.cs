using Expense.Application.Features.EmployeePhones.Models;
using MediatR;

namespace Expense.Application.Features.EmployeePhones.Queries.Get;

public class GetEmployeePhoneByIdQuery : IRequest<EmployeePhoneResponse>
{
	public long Id { get; set; }

	public GetEmployeePhoneByIdQuery(long id)
	{
		Id = id;
	}
}