using MediatR;
using Base.Application.Features.Auth.Login.Models;

namespace Base.Application.Features.Auth.Login.Commands;

public class LoginCommand : IRequest<LoginResponseDto>
{
	public LoginRequestDto LoginRequest { get; set; }

	public LoginCommand(LoginRequestDto loginRequest)
	{
		LoginRequest = loginRequest;
	}
}