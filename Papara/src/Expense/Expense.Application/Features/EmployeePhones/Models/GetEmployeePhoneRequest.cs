namespace Expense.Application.Features.EmployeePhones.Models;

public class GetEmployeePhoneRequest
{
	public bool IsPrimary { get; set; }
	public long EmployeeId { get; set; }
	public bool IncludeEmployee { get; set; } = false;
}