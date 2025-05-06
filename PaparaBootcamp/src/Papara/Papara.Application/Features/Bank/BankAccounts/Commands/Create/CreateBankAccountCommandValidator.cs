using FluentValidation;
using Papara.Application.Features.Bank.BankAccounts.Commands.Create;

namespace Papara.Application.Features.Bank.BankAccounts.Validators;

public class CreateBankAccountCommandValidator : AbstractValidator<CreateBankAccountCommand>
{
	public CreateBankAccountCommandValidator()
	{
		RuleFor(x => x.Request.AccountHolderName)
			.NotEmpty().WithMessage("Hesap sahibi adı boş olamaz.")
			.MaximumLength(150).WithMessage("Hesap sahibi adı en fazla 150 karakter olabilir.");

		RuleFor(x => x.Request.IBAN)
			.NotEmpty().WithMessage("IBAN zorunludur.")
			.MaximumLength(34).WithMessage("IBAN en fazla 34 karakter olabilir.")
			.Matches(@"^TR\d{2}\d{16,30}$").WithMessage("Geçerli bir IBAN giriniz. (TR ile başlamalıdır)");

		RuleFor(x => x.Request.AccountType)
			.IsInEnum().WithMessage("Geçerli bir hesap türü seçiniz.");
	}
}
