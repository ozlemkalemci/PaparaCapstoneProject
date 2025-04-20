using Base.Domain.Entities;

namespace Expense.Domain.Entities;

public class EmployeeAddress : BaseEntity
{
	public string City { get; set; } = null!;
	public string District { get; set; } = null!;
	public string Detail { get; set; } = null!;

	public long EmployeeId { get; set; }
	public Employee Employee { get; set; } = null!;
}