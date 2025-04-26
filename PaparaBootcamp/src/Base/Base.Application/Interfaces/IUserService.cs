namespace Base.Application.Interfaces
{
	public interface IUserService
	{
		Task<long?> GetEmployeeIdByUserIdAsync(long userId);
	}
}
