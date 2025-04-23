using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense.Application.Features.EmployeePhones.Commands.Delete;

public class DeleteEmployeePhoneCommand : IRequest<Unit>
{
	public long Id { get; }

	public DeleteEmployeePhoneCommand(long id)
	{
		Id = id;
	}
}