using MediatR;
using Base.Application.Features.Auth.Register.Models;

namespace Base.Application.Features.Auth.Register.Commands;

public class RegisterCommand : IRequest<RegisterResponseDto>
{
	public RegisterRequestDto Request { get; }

	public RegisterCommand(RegisterRequestDto request)
	{
		Request = request;
	}
}