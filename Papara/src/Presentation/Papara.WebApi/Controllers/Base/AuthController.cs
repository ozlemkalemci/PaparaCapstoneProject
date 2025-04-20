using Base.Application.Features.Auth.Login.Commands;
using Base.Application.Features.Auth.Login.Models;
using Base.Application.Features.Auth.Register.Commands;
using Base.Application.Features.Auth.Register.Models;
using Microsoft.AspNetCore.Mvc;

namespace Papara.WebApi.Controllers.Base;
public class AuthController : ApiControllerBase
{
	[HttpPost("login")]
	public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
	{
		var result = await Mediator.Send(new LoginCommand(request));
		return Ok(result);
	}

	[HttpPost("register")]
	public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
	{
		var result = await Mediator.Send(new RegisterCommand(request));
		return Ok(result);
	}
}