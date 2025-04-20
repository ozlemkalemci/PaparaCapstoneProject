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

}