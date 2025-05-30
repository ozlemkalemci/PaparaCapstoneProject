﻿using Papara.Application.Features.Corporation.Departments.Models;

namespace Papara.Application.Features.HR.Employees.Models;

public class EmployeeResponse
{
	public long Id { get; set; }
	public string FirstName { get; set; } = null!;
	public string? MiddleName { get; set; }
	public string LastName { get; set; } = null!;
	public string IdentityNumber { get; set; } = null!;
	public string IBAN { get; set; } = null!;
	public long? UserId { get; set; }
	public long DepartmentId { get; set; }

	public DepartmentResponse? ResponseDepartment { get; set; }

}   