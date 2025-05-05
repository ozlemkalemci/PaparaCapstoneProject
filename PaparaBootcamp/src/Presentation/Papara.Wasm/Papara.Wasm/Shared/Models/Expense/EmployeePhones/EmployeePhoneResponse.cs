using Papara.Wasm.Shared.Models.Expense.Employees;
using System.ComponentModel.DataAnnotations;

namespace Papara.Wasm.Shared.Models.Expense.EmployeePhones;

public class EmployeePhoneResponse
{
	public long Id { get; set; }
	public string PhoneNumber { get; set; }
	public bool IsPrimary { get; set; }
	public long EmployeeId { get; set; }
	public PhoneType Type { get; set; }

	public EmployeeResponse? ResponseEmployee { get; set; }
}

public enum PhoneType : byte
{
	[Display(Name = "Mobil")]
	Mobile = 1,

	[Display(Name = "Ev")]
	Home = 2,

	[Display(Name = "İş")]
	Work = 3,
}