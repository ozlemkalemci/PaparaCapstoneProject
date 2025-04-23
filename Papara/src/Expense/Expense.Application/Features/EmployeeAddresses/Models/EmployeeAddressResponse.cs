using Expense.Application.Features.Employees.Models;

namespace Expense.Application.Features.EmployeeAddresses.Models;

public class EmployeeAddressResponse
{
	public long Id { get; set; }
	public string City { get; set; } = null!;
	public string District { get; set; } = null!;
	public string Detail { get; set; } = null!;
	public long EmployeeId { get; set; }

	public EmployeeResponse? ResponseEmployee { get; set; }
}