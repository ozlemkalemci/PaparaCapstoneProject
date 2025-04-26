using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using Papara.Domain.Entities.HR;
using System.Linq.Expressions;

namespace Papara.Application.Services.Auth;

public class UserService : IUserService
{
	private readonly IUnitOfWork _unitOfWork;

	public UserService(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<long?> GetEmployeeIdByUserIdAsync(long userId)
	{
		var filter = (Expression<Func<Employee, bool>>)(x => x.UserId == userId && x.IsActive);
		var employee = await _unitOfWork.Repository<Employee>().GetAllAsync(filter);

		var firstEmployee = employee.FirstOrDefault();
		return firstEmployee?.Id;
	}
}
