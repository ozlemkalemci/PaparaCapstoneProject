using Papara.Application.Features.HR.Employees.Models;
using Papara.Domain.Enums.Hr;

namespace Papara.Application.Features.HR.EmployeePhones.Models;

public class EmployeePhoneResponse
{
	public long Id { get; set; }
	public string PhoneNumber { get; set; }
	public bool IsPrimary { get; set; }
	public long EmployeeId { get; set; }
	public PhoneType Type { get; set; }

	public EmployeeResponse? ResponseEmployee { get; set; }
}