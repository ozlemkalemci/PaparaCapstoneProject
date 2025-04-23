using Base.Application.Features.Auth.RefreshTokens.Models;
using Base.Application.Interfaces;
using Base.Domain.Identity;
using Base.Domain.Interfaces;
using MediatR;

namespace Base.Application.Features.Auth.RefreshTokens.Commands;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, RefreshTokenResponse>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IJwtService _jwtService;
	private readonly IRefreshTokenGenerator _refreshTokenGenerator;

	public RefreshTokenCommandHandler(
		IUnitOfWork unitOfWork,
		IJwtService jwtService,
		IRefreshTokenGenerator refreshTokenGenerator)
	{
		_unitOfWork = unitOfWork;
		_jwtService = jwtService;
		_refreshTokenGenerator = refreshTokenGenerator;
	}

	public async Task<RefreshTokenResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
	{
		var refreshToken = request.Request.RefreshToken;

		// Tüm refresh token’ları tara (ideal olarak indexlenmeli)
		var tokens = await _unitOfWork.Repository<RefreshToken>()
			.GetAllAsync(x => x.IsActive);

		var matched = tokens.FirstOrDefault(x =>
			_refreshTokenGenerator.VerifyToken(refreshToken, x.TokenHash, x.TokenSalt) &&
			x.Expiration > DateTimeOffset.UtcNow);

		if (matched == null)
			throw new UnauthorizedAccessException("Geçersiz refresh token.");

		// Eski token'ı devre dışı bırak
		_unitOfWork.Repository<RefreshToken>().Delete(matched);

		// Yeni refresh token üret
		var newToken = _refreshTokenGenerator.GenerateToken();
		var (newHash, newSalt) = _refreshTokenGenerator.HashToken(newToken);
		var refreshTokenExpire = DateTimeOffset.UtcNow.AddDays(7);

		await _unitOfWork.Repository<RefreshToken>().AddAsync(new RefreshToken
		{
			UserId = matched.UserId,
			TokenHash = newHash,
			TokenSalt = newSalt,
			Expiration = refreshTokenExpire,
			CreatedById = matched.UserId,
			CreatedDate = DateTimeOffset.UtcNow,
			IsActive = true
		});

		await _unitOfWork.CommitAsync();

		// Yeni access token üret
		var user = (await _unitOfWork.Repository<User>().GetByIdAsync(matched.UserId))!;
		var accessToken = _jwtService.GenerateToken(user);

		return new RefreshTokenResponse
		{
			AccessToken = accessToken,
			Expiration = DateTime.UtcNow.AddMinutes(60),
			RefreshToken = newToken,
			RefreshTokenExpiration = refreshTokenExpire
		};
	}
}
