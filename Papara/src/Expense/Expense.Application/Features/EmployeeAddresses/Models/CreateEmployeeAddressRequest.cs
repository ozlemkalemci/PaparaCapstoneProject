namespace Expense.Application.Features.EmployeeAddresses.Models;

public class CreateEmployeeAddressRequest
{
	public string City { get; set; } = null!;
	public string District { get; set; } = null!;
	public string Detail { get; set; } = null!;
	public long EmployeeId { get; set; }
}
