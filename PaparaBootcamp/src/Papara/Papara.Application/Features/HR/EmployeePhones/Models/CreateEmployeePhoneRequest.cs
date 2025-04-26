using Papara.Domain.Enums.Hr;

namespace Papara.Application.Features.HR.EmployeePhones.Models;

public class CreateEmployeePhoneRequest
{
	public string PhoneNumber { get; set; }
	public bool IsPrimary { get; set; }
	public long EmployeeId { get; set; }
	public PhoneType Type { get; set; }
}
