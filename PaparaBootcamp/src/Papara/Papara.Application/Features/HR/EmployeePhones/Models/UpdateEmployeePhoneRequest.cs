namespace Papara.Application.Features.HR.EmployeePhones.Models;

public class UpdateEmployeePhoneRequest
{
	public string PhoneNumber { get; set; }
	public bool IsPrimary { get; set; }
}