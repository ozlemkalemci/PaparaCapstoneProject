namespace Expense.Application.Features.EmployeeAddresses.Models;

public class GetEmployeeAddressRequest
{
	public string? City { get; set; }
	public string? District { get; set; } 
	public string? Detail { get; set; } 
	public long EmployeeId { get; set; }
	public bool IncludeEmployee { get; set; } = false;
}