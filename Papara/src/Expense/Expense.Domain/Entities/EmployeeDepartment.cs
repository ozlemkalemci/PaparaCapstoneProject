using Base.Domain.Entities;

namespace Expense.Domain.Entities;

public class EmployeeDepartment : BaseEntity
{
	public string DepartmentName { get; set; } = null!;
	public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
