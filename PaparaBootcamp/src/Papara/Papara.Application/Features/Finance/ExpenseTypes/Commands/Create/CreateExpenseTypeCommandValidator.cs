using FluentValidation;

namespace Papara.Application.Features.Finance.ExpenseTypes.Commands.Create;

public class CreateExpenseTypeCommandValidator : AbstractValidator<CreateExpenseTypeCommand>
{
	public CreateExpenseTypeCommandValidator()
	{
		RuleFor(x => x.Request.Name)
			.NotEmpty().WithMessage("Kategori adı boş olamaz.")
			.MaximumLength(100).WithMessage("Kategori adı en fazla 100 karakter olabilir.");

		RuleFor(x => x.Request.Description)
			.NotEmpty().WithMessage("Açıklama boş olamaz.")
			.MaximumLength(300).WithMessage("Açıklama en fazla 300 karakter olabilir.");
	}
}
