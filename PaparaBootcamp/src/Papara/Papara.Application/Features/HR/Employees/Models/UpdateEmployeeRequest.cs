namespace Papara.Application.Features.HR.Employees.Models;

public class UpdateEmployeeRequest
{
	public string Email { get; set; } = null!;
	public long DepartmentId { get; set; }
	public long? UserId { get; set; }
	public bool IsActive { get; set; }
}