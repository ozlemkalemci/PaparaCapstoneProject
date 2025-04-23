using Base.Application.Features.Auth.RefreshTokens.Models;
using MediatR;

namespace Base.Application.Features.Auth.RefreshTokens.Commands;

public class RefreshTokenCommand : IRequest<RefreshTokenResponse>
{
	public RefreshTokenRequest Request { get; }

	public RefreshTokenCommand(RefreshTokenRequest request)
	{
		Request = request;
	}
}