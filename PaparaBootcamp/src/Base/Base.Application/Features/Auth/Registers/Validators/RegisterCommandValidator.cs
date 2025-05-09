﻿using FluentValidation;
using Base.Application.Features.Auth.Registers.Commands;

namespace Base.Application.Features.Auth.Registers.Validators;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
	public RegisterCommandValidator()
	{
		RuleFor(x => x.Request.UserName)
			.NotEmpty().WithMessage("Kullanıcı adı boş olamaz.");

		RuleFor(x => x.Request.Password)
			.NotEmpty().MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalı.");

		RuleFor(x => x.Request.Role)
			.NotNull().WithMessage("Geçersiz rol.");

		RuleFor(x => x.Request.Email)
			.NotEmpty().WithMessage("E-posta boş olamaz.")
			.EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");
	}
}