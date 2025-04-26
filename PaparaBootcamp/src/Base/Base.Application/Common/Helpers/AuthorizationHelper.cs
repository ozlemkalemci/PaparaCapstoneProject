using Base.Application.Common.Exceptions;
using Base.Application.Interfaces;

namespace Base.Application.Common.Helpers;

public static class AuthorizationHelper
{
	public static void EnsureEmployeeOwnsData(IUserContextService userContextService, long ownerId)
	{
		if (userContextService.GetCurrentEmployeeId() != ownerId)
		{
			throw new ForbidException();
		}
	}
}
