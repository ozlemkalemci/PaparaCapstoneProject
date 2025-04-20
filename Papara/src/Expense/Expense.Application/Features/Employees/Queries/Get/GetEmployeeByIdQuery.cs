using Expense.Application.Features.Employees.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense.Application.Features.Employees.Queries.Get;

public class GetEmployeeByIdQuery : IRequest<EmployeeResponseDto>
{
	public long Id { get; set; }

	public GetEmployeeByIdQuery(long id)
	{
		Id = id;
	}
}
