using Base.Domain.Entities;
using Expense.Domain.Enums;

namespace Expense.Domain.Entities;

public class EmployeePhone : BaseEntity
{
	public string PhoneNumber { get; set; } = null!;
	public bool IsPrimary { get; set; }
	public PhoneType Type { get; set; }
	public long EmployeeId { get; set; }
	public Employee Employee { get; set; } = null!;
}