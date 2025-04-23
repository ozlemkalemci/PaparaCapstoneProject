namespace Expense.Application.Features.EmployeePhones.Models;

public class UpdateEmployeePhoneRequest
{
	public string PhoneNumber { get; set; }
	public bool IsPrimary { get; set; }
}