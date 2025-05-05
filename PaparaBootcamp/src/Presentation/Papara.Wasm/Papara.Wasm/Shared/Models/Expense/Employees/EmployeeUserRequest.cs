using Papara.Wasm.Shared.Models.Auth;

namespace Papara.Wasm.Shared.Models.Expense.Employees;

public class EmployeeUserRequest
{
	public RegisterRequest Request { get; set; } = new();
	public long EmployeeId { get; set; }
}
