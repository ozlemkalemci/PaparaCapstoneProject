using Base.Application.Interfaces;
using Base.Domain.Identity;
using Base.Domain.Interfaces;
using Papara.Application.Services.EmployeeUsers.Models;
using Papara.Domain.Entities.HR;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Papara.Application.Services.EmployeeUsers;

public class EmployeeUserService : IEmployeeUserService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IPasswordHasher _passwordHasher;

	public EmployeeUserService(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
	{
		_unitOfWork = unitOfWork;
		_passwordHasher = passwordHasher;
	}

	public async Task CreateUserAndAssignToEmployeeAsync(EmployeeUserRequest request)
	{
		try
		{
			var userDto = request.Request;

			var existingUser = (await _unitOfWork.Repository<User>()
				.Where(x => x.UserName == userDto.UserName))
				.FirstOrDefault();

			if (existingUser != null)
				throw new InvalidOperationException("Bu kullanıcı adı zaten alınmış.");

			var employee = await _unitOfWork.Repository<Employee>().GetByIdAsync(request.EmployeeId);
			if (employee == null)
				throw new KeyNotFoundException("İlgili çalışan bulunamadı.");

			if (employee.UserId.HasValue)
				throw new InvalidOperationException("Bu çalışanın zaten bir kullanıcı kaydı var.");

			var passwordHash = _passwordHasher.Hash(userDto.Password);
			var secret = Guid.NewGuid().ToString();

			var user = new User
			{
				UserName = userDto.UserName,
				PasswordHash = passwordHash,
				Secret = secret,
				Role = userDto.Role,
				OpenDate = DateTimeOffset.UtcNow,
				IsActive = true,
				CreatedDate = DateTimeOffset.UtcNow,
				CreatedById = 0,
				Email = userDto.Email,
			};

			await _unitOfWork.Repository<User>().AddAsync(user);
			await _unitOfWork.CommitAsync();

			employee.UserId = user.Id;
			_unitOfWork.Repository<Employee>().Update(employee);

			await _unitOfWork.CommitAsync();
		}
		catch (Exception ex)
		{

			throw ex;
		}
	}
}
