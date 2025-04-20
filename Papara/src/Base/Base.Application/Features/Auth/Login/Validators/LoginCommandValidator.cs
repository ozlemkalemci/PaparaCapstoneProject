using FluentValidation;
using Base.Application.Features.Auth.Login.Commands;

namespace Base.Application.Features.Auth.Login.Validators;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
	public LoginCommandValidator()
	{
		RuleFor(x => x.LoginRequest.UserName)
			.NotEmpty().WithMessage("Kullanıcı adı boş olamaz.");

		RuleFor(x => x.LoginRequest.Password)
			.NotEmpty().WithMessage("Şifre boş olamaz.");
	}
}