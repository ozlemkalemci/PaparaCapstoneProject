using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Papara.Application.Services.EmployeeUsers.Models;
using Papara.Application.Services.EmployeeUsers;
using Papara.WebApi.Controllers.Base;

namespace Papara.WebApi.Controllers.Papara.HR;

[ApiController]
[Route("api/employee-users")]
public class EmployeeUsersController : ApiControllerBase
{
	private readonly IEmployeeUserService _employeeUserService;

	public EmployeeUsersController(IEmployeeUserService employeeUserService)
	{
		_employeeUserService = employeeUserService;
	}

	/// <summary>
	/// Kullanıcı oluşturur ve çalışan kaydı ile ilişkilendirir. Sadece admin yapabilir.
	/// </summary>
	[HttpPost]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> CreateUserForEmployee([FromBody] EmployeeUserRequest request)
	{
		await _employeeUserService.CreateUserAndAssignToEmployeeAsync(request);
		return Ok("Kullanıcı başarıyla oluşturuldu ve çalışana bağlandı.");
	}
}
