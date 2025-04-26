using Base.Application.Features.Auth.Logins.Models;
using Base.Application.Interfaces;
using Base.Domain.Identity;
using Base.Domain.Interfaces;
using MediatR;

namespace Base.Application.Features.Auth.Logins.Commands;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IJwtService _jwtService;
	private readonly IPasswordHasher _passwordHasher;
	private readonly IRefreshTokenGenerator _refreshTokenGenerator;
	public LoginCommandHandler(
		IUnitOfWork unitOfWork,
		IJwtService jwtService,
		IPasswordHasher passwordHasher,
		IRefreshTokenGenerator refreshTokenGenerator)
	{
		_unitOfWork = unitOfWork;
		_jwtService = jwtService;
		_passwordHasher = passwordHasher;
		_refreshTokenGenerator = refreshTokenGenerator;
	}

	public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
	{

		var refreshToken = _refreshTokenGenerator.GenerateToken();
		var (hash, salt) = _refreshTokenGenerator.HashToken(refreshToken);
		var refreshTokenExpiration = DateTimeOffset.UtcNow.AddDays(7);

		var dto = request.LoginRequest;

		var user = (await _unitOfWork.Repository<User>()
			.Where(u => u.UserName == dto.UserName && u.IsActive))
			.FirstOrDefault();

		if (user == null || !_passwordHasher.Verify(dto.Password, user.PasswordHash))
		{
			throw new UnauthorizedAccessException("Kullanıcı adı veya şifre hatalı.");
		}

		var token = _jwtService.GenerateToken(user);

		// Kullanıcının aktif refresh token'ını sil
		var activeTokens = await _unitOfWork.Repository<RefreshToken>()
			.GetAllAsync(x => x.UserId == user.Id && x.IsActive);

		if (activeTokens.Any())
		{
			foreach (var activeToken in activeTokens)
				_unitOfWork.Repository<RefreshToken>().Delete(activeToken);

			await _unitOfWork.CommitAsync();
		}

		await _unitOfWork.Repository<RefreshToken>().AddAsync(new RefreshToken
		{
			UserId = user.Id,
			TokenHash = hash,
			TokenSalt = salt,
			Expiration = refreshTokenExpiration,
			CreatedDate = DateTimeOffset.UtcNow,
			CreatedById = user.Id,
			IsActive = true
		});

		await _unitOfWork.CommitAsync();

		return new LoginResponse
		{
			AccessToken = token,
			Expiration = DateTime.UtcNow.AddMinutes(60),
			RefreshToken = refreshToken,
			RefreshTokenExpiration = refreshTokenExpiration
		};
	}
}
