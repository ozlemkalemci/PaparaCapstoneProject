namespace Papara.Application.Features.HR.Employees.Models;

public class GetEmployeeRequest
{
	public long? DepartmentId { get; set; }
	public bool IncludeUser { get; set; } = false;
	public bool IncludeDepartment { get; set; } = false;
	public bool IncludePhones { get; set; } = false;
	public bool IncludeAddresses { get; set; } = false;
}