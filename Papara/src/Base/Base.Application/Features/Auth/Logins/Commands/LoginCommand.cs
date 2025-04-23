using MediatR;
using Base.Application.Features.Auth.Logins.Models;

namespace Base.Application.Features.Auth.Logins.Commands;

public class LoginCommand : IRequest<LoginResponse>
{
	public LoginRequest LoginRequest { get; set; }

	public LoginCommand(LoginRequest loginRequest)
	{
		LoginRequest = loginRequest;
	}
}