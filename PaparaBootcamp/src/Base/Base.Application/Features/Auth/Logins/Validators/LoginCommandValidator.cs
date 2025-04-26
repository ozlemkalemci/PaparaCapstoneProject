using FluentValidation;
using Base.Application.Features.Auth.Logins.Commands;

namespace Base.Application.Features.Auth.Logins.Validators;

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