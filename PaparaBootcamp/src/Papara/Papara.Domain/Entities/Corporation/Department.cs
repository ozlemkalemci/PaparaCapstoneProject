using Base.Domain.Entities;
using Papara.Domain.Entities.HR;

namespace Papara.Domain.Entities.Corporation;

public class Department : BaseEntity
{
	public string DepartmentName { get; set; } = null!;
	public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
