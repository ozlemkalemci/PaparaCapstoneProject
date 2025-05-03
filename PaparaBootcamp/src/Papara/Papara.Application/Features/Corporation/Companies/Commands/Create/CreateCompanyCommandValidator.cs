using FluentValidation;

namespace Papara.Application.Features.Corporation.Companies.Commands.Create;

public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
{
	public CreateCompanyCommandValidator()
	{
		RuleFor(x => x.Request.CompanyName)
			.NotEmpty().WithMessage("Firma adı boş olamaz.")
			.MaximumLength(100).WithMessage("Firma adı en fazla 100 karakter olabilir.");
	}
}