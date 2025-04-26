using Microsoft.AspNetCore.Http;
using Base.Application.Interfaces;
using System.Security.Claims;

namespace Base.Infrastructure.Services;

public class UserContextService : IUserContextService
{
	private readonly IHttpContextAccessor _httpContextAccessor;

	public UserContextService(IHttpContextAccessor httpContextAccessor)
	{
		_httpContextAccessor = httpContextAccessor;
	}

	public long? GetCurrentUserId()
	{
		var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		return long.TryParse(userIdClaim, out var id) ? id : null;
	}
	public string? GetCurrentUserRole()
	{
		var roleClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Role)?.Value;
		return roleClaim;
	}
	public long? GetCurrentEmployeeId()
	{
		var employeeIdClaim = _httpContextAccessor.HttpContext?.User?.Claims
			.FirstOrDefault(c => c.Type == "EmployeeId");

		if (employeeIdClaim != null && long.TryParse(employeeIdClaim.Value, out var employeeId))
		{
			return employeeId;
		}

		return null;
	}

}