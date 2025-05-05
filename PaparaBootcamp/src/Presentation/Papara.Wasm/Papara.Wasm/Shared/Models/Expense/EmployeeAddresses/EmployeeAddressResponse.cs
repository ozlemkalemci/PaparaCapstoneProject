using Papara.Wasm.Shared.Models.Expense.Employees;

namespace Papara.Wasm.Shared.Models.Expense.EmployeeAddresses;

public class EmployeeAddressResponse
{
	public long Id { get; set; }
	public string City { get; set; } = null!;
	public string District { get; set; } = null!;
	public string Detail { get; set; } = null!;
	public long EmployeeId { get; set; }

	public EmployeeResponse? ResponseEmployee { get; set; }
}
