using Papara.Application.Features.HR.Employees.Models;

namespace Papara.Application.Features.HR.EmployeeAddresses.Models;

public class EmployeeAddressResponse
{
	public long Id { get; set; }
	public string City { get; set; } = null!;
	public string District { get; set; } = null!;
	public string Detail { get; set; } = null!;
	public long EmployeeId { get; set; }

	public EmployeeResponse? ResponseEmployee { get; set; }
}