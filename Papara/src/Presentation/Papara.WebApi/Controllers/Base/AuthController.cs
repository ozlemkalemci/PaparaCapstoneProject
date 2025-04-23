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
public class AuthController : ApiControllerBase
{
	[HttpPost("login")]
	public async Task<IActionResult> Login([FromBody] LoginRequest request)
	{
		var result = await Mediator.Send(new LoginCommand(request));
		return Ok(result);
	}

	[HttpPost("register")]
	public async Task<IActionResult> Register([FromBody] RegisterRequest request)
	{
		var result = await Mediator.Send(new RegisterCommand(request));
		return Ok(result);
	}

	[HttpPost("logout")]
	[Authorize]
	public async Task<IActionResult> Logout()
	{
		await Mediator.Send(new LogoutCommand());
		return Ok(new { message = "Çıkış yapıldı." });
	}
	[HttpPost("refresh-token")]
	public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
	{
		var result = await Mediator.Send(new RefreshTokenCommand(request));
		return Ok(result);
	}
}