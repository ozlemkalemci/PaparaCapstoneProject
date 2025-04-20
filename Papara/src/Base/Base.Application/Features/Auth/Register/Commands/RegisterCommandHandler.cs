using MediatR;
using Base.Application.Features.Auth.Register.Models;
using Base.Application.Interfaces;
using Base.Domain.Identity;
using Base.Domain.Interfaces;

namespace Base.Application.Features.Auth.Register.Commands;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponseDto>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IPasswordHasher _passwordHasher;

	public RegisterCommandHandler(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
	{
		_unitOfWork = unitOfWork;
		_passwordHasher = passwordHasher;
	}

	public async Task<RegisterResponseDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
	{
		var dto = request.Request;

		var existingUser = (await _unitOfWork.Repository<User>()
			.Where(x => x.UserName == dto.UserName))
			.FirstOrDefault();

		if (existingUser != null)
			throw new Exception("Bu kullanıcı adı zaten alınmış.");

		var passwordHash = _passwordHasher.Hash(dto.Password);
		var secret = Guid.NewGuid().ToString();

		var user = new User
		{
			UserName = dto.UserName,
			PasswordHash = passwordHash,
			Secret = secret,
			Role = (Domain.Enums.UserRole)dto.Role,
			OpenDate = DateTimeOffset.UtcNow,
			IsActive = true,
			CreatedDate = DateTimeOffset.UtcNow,
			CreatedById = 0 // sıfır demek bu kullanıcıyı sistem otomatik olarak oluşturdu, yani oluşturan başka bir kullanıcı yok demek
		};

		await _unitOfWork.Repository<User>().AddAsync(user);
		await _unitOfWork.CommitAsync();

		return new RegisterResponseDto
		{
			UserId = user.Id,
			UserName = user.UserName,
			Role = user.Role
		};
	}
}