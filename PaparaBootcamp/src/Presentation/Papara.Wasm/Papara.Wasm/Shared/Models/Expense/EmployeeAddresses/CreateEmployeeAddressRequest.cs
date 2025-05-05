namespace Papara.Wasm.Shared.Models.Expense.EmployeeAddresses
{
	public class CreateEmployeeAddressRequest
	{
		public string City { get; set; } = null!;
		public string District { get; set; } = null!;
		public string Detail { get; set; } = null!;
		public long EmployeeId { get; set; }
	}
}
