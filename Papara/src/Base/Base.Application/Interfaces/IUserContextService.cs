namespace Base.Application.Interfaces;

public interface IUserContextService
{
	long? GetCurrentUserId();
	string? GetCurrentUserRole();
}