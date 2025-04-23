using MediatR;
using Base.Application.Features.Auth.Registers.Models;

namespace Base.Application.Features.Auth.Registers.Commands;

public class RegisterCommand : IRequest<RegisterResponse>
{
	public RegisterRequest Request { get; }

	public RegisterCommand(RegisterRequest request)
	{
		Request = request;
	}
}