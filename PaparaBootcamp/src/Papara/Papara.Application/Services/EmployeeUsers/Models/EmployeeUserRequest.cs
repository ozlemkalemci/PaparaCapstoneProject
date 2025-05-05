using Base.Application.Features.Auth.Registers.Models;

namespace Papara.Application.Services.EmployeeUsers.Models;

public class EmployeeUserRequest
{
	public RegisterRequest Request { get; set; }
	public long EmployeeId { get; set; }
}
