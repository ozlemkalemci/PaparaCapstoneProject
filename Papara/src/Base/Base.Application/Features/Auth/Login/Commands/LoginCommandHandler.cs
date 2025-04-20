using MediatR;
using Base.Application.Features.Auth.Login.Models;
using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using Base.Domain.Identity;

namespace Base.Application.Features.Auth.Login.Commands;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponseDto>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IJwtService _jwtService;
	private readonly IPasswordHasher _passwordHasher;

	public LoginCommandHandler(
		IUnitOfWork unitOfWork,
		IJwtService jwtService,
		IPasswordHasher passwordHasher)
	{
		_unitOfWork = unitOfWork;
		_jwtService = jwtService;
		_passwordHasher = passwordHasher;
	}

	public async Task<LoginResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
	{
		var dto = request.LoginRequest;

		var user = (await _unitOfWork.Repository<User>()
			.Where(u => u.UserName == dto.UserName && u.IsActive))
			.FirstOrDefault();

		if (user == null || !_passwordHasher.Verify(dto.Password, user.PasswordHash))
		{
			throw new UnauthorizedAccessException("Kullanıcı adı veya şifre hatalı.");
		}

		var token = _jwtService.GenerateToken(user);

		return new LoginResponseDto
		{
			AccessToken = token,
			Expiration = DateTime.UtcNow.AddMinutes(60)
		};
	}
}
