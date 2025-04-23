using Expense.Application.Features.EmployeeAddresses.Models;
using Expense.Application.Features.EmployeeDepartments.Models;
using Expense.Application.Features.EmployeePhones.Models;

namespace Expense.Application.Features.Employees.Models;

public class EmployeeResponse
{
	public long Id { get; set; }
	public string Email { get; set; } = null!;
	public string FirstName { get; set; } = null!;
	public string? MiddleName { get; set; }
	public string LastName { get; set; } = null!;
	public string IdentityNumber { get; set; } = null!;
	public string IBAN { get; set; } = null!;
	public long? UserId { get; set; }
	public long DepartmentId { get; set; }

	public EmployeeDepartmentResponse? ResponseDepartment { get; set; }
	public List<EmployeePhoneResponse>? ResponsePhones { get; set; }
	public List<EmployeeAddressResponse>? ResponseAddresses { get; set; }
}