using Base.Application.Interfaces;
using Base.Domain.Identity;
using Base.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Base.Application.Features.Auth.Logouts.Commands;

public class LogoutCommandHandler : IRequestHandler<LogoutCommand, Unit>
{
	private readonly IRedisService _redisService;
	private readonly IHttpContextAccessor _httpContextAccessor;
	private readonly IUnitOfWork _unitOfWork;
	public LogoutCommandHandler(IRedisService redisService, 
		IHttpContextAccessor httpContextAccessor, 
		IUnitOfWork unitOfWork)
	{
		_redisService = redisService;
		_httpContextAccessor = httpContextAccessor;
		_unitOfWork = unitOfWork;
	}

	public async Task<Unit> Handle(LogoutCommand request, CancellationToken cancellationToken)
	{
		var httpContext = _httpContextAccessor.HttpContext;
		var jti = httpContext?.User?.FindFirst("jti")?.Value;
		var expStr = httpContext?.User?.FindFirst("exp")?.Value;
		var userId = httpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;


		if (string.IsNullOrEmpty(jti) || string.IsNullOrEmpty(expStr))
			throw new UnauthorizedAccessException("Token geçersiz.");

		var expUnix = long.Parse(expStr);
		var expiration = DateTimeOffset.FromUnixTimeSeconds(expUnix);

		await _redisService.AddToBlacklistAsync(jti, expiration);

		// Kullanıcının aktif refresh token'ını sil
		var activeTokens = await _unitOfWork.Repository<RefreshToken>()
			.GetAllAsync(x => x.UserId.ToString() == userId && x.IsActive);

		if (activeTokens.Any())
		{
			foreach (var token in activeTokens)
				_unitOfWork.Repository<RefreshToken>().Delete(token);

			await _unitOfWork.CommitAsync();
		}

		return Unit.Value;
	}
}