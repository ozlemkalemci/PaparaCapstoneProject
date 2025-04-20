using Base.Domain.Entities;
using Base.Domain.Identity;

namespace Expense.Domain.Entities;

public class Employee : BaseEntity
{
	public string Email { get; set; } = null!;
	public string FirstName { get; set; } = null!;
	public string? MiddleName { get; set; }
	public string LastName { get; set; } = null!;
	public string IdentityNumber { get; set; } = null!;
	public string IBAN { get; set; } = null!;

	public long? UserId { get; set; }
	public virtual User? User { get; set; } = null!;

	public long DepartmentId { get; set; }
	public virtual EmployeeDepartment? Department { get; set; } = null!;

	public virtual ICollection<EmployeeAddress>? Addresses { get; set; } = new List<EmployeeAddress>();
	public virtual ICollection<EmployeePhone>? Phones { get; set; } = new List<EmployeePhone>();
}