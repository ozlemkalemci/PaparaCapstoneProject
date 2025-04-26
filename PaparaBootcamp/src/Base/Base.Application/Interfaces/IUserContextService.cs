namespace Base.Application.Interfaces;

public interface IUserContextService
{
	long? GetCurrentUserId();
	long? GetCurrentEmployeeId();
	string? GetCurrentUserRole();
}