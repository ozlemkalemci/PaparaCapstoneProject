namespace Papara.Wasm.Shared.Models.Expense.EmployeePhones
{
	public class UpdateEmployeePhoneRequest
	{
		public string PhoneNumber { get; set; }
		public bool IsPrimary { get; set; }
		public PhoneType Type { get; set; }
	}
}
