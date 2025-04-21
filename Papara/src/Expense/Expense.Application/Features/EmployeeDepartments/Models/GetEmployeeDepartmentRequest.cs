using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense.Application.Features.EmployeeDepartments.Models;

public class GetEmployeeDepartmentRequest
{
	public string? DepartmentName { get; set; } = null!;
}