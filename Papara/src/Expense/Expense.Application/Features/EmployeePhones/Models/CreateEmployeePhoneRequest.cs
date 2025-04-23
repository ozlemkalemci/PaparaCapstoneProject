using Expense.Domain.Enums;

namespace Expense.Application.Features.EmployeePhones.Models;

public class CreateEmployeePhoneRequest
{
	public string PhoneNumber { get; set; }
	public bool IsPrimary { get; set; }
	public long EmployeeId { get; set; }
	public PhoneType Type { get; set; }
}
