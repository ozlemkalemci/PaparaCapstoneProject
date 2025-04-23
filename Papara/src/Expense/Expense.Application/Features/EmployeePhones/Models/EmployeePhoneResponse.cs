using Expense.Application.Features.Employees.Models;
using Expense.Domain.Enums;

namespace Expense.Application.Features.EmployeePhones.Models;

public class EmployeePhoneResponse
{
	public long Id { get; set; }
	public string PhoneNumber { get; set; }
	public bool IsPrimary { get; set; }
	public long EmployeeId { get; set; }
	public PhoneType Type { get; set; }

	public EmployeeResponse? ResponseEmployee { get; set; }
}