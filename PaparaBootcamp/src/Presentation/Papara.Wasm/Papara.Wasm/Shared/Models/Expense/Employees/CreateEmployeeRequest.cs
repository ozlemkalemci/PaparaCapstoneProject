﻿namespace Papara.Wasm.Shared.Models.Expense.Employees;

public class CreateEmployeeRequest
{
	public string FirstName { get; set; } = null!;
	public string? MiddleName { get; set; }
	public string LastName { get; set; } = null!;
	public string IdentityNumber { get; set; } = null!;
	public string IBAN { get; set; } = null!;
	public long? UserId { get; set; }
	public long DepartmentId { get; set; }
}
