using FluentValidation;

namespace Papara.Application.Features.Corporation.Companies.Commands.Update;

public class UpdateCompanyCommandValidator : AbstractValidator<UpdateCompanyCommand>
{
	public UpdateCompanyCommandValidator()
	{
		RuleFor(x => x.Request.CompanyName)
			.NotEmpty().WithMessage("Firma adı boş olamaz.")
			.MaximumLength(100).WithMessage("Firma adı en fazla 100 karakter olabilir.");
	}
}