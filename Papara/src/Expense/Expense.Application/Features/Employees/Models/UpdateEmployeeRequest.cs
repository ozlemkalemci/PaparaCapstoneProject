using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense.Application.Features.Employees.Models;

public class UpdateEmployeeRequest
{
	public string Email { get; set; } = null!;
	public long DepartmentId { get; set; }
	public long? UserId { get; set; }
}