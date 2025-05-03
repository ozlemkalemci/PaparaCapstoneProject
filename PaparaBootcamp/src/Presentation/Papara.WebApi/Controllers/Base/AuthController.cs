using Base.Application.Features.Auth.Logins.Commands;
using Base.Application.Features.Auth.Logins.Models;
using Base.Application.Features.Auth.Logouts.Commands;
using Base.Application.Features.Auth.RefreshTokens.Commands;
using Base.Application.Features.Auth.RefreshTokens.Models;
using Base.Application.Features.Auth.Registers.Commands;
using Base.Application.Features.Auth.Registers.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Papara.WebApi.Controllers.Base;

[ApiController]
[Route("api/auth")]
public class AuthController : ApiControllerBase
{
	/// <summary>
	/// Sisteme giriş yapar ve JWT token döner.
	/// </summary>
	/// <param name="request">Giriş bilgileri</param>
	[HttpPost("login")]
	public async Task<IActionResult> Login([FromBody] LoginRequest request)
	{
		var result = await Mediator.Send(new LoginCommand(request));
		return Ok(result);
	}

	/// <summary>
	/// Yeni kullanıcı kaydı oluşturur.
	/// </summary>
	/// <param name="request">Kayıt bilgileri</param>
	[HttpPost("register")]
	public async Task<IActionResult> Register([FromBody] RegisterRequest request)
	{
		var result = await Mediator.Send(new RegisterCommand(request));
		return Ok(result);
	}

	/// <summary>
	/// Oturumu sonlandırır ve token’ı kara listeye ekler.
	/// </summary>
	[HttpPost("logout")]
	[Authorize]
	public async Task<IActionResult> Logout()
	{
		await Mediator.Send(new LogoutCommand());
		return Ok(new { message = "Çıkış yapıldı." });
	}

	/// <summary>
	/// Yeni bir access token almak için refresh token kullanılır.
	/// </summary>
	/// <param name="request">Refresh token bilgisi</param>
	[HttpPost("refresh-token")]
	public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
	{
		var result = await Mediator.Send(new RefreshTokenCommand(request));
		return Ok(result);
	}
}
