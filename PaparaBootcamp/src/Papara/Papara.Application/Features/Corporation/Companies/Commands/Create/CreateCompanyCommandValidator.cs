using FluentValidation;

namespace Papara.Application.Features.Corporation.Companies.Commands.Create;

public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
{
	public CreateCompanyCommandValidator()
	{
		RuleFor(x => x.Request.CompanyName)
			.NotEmpty().WithMessage("Şirket adı boş olamaz.")
			.MaximumLength(200).WithMessage("Şirket adı en fazla 200 karakter olabilir.");

		RuleFor(x => x.Request.TaxNumber)
			.NotEmpty().WithMessage("Vergi numarası zorunludur.")
			.Length(10).WithMessage("Vergi numarası 10 haneli olmalıdır.");

		RuleFor(x => x.Request.CompanyIBAN)
			.NotEmpty().WithMessage("Şirket IBAN bilgisi zorunludur.")
			.MaximumLength(34).WithMessage("IBAN en fazla 34 karakter olabilir.");
	}
}