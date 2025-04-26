using FluentValidation;

namespace Papara.Application.Features.Finance.ExpenseTypes.Commands.Update;

public class UpdateExpenseTypeCommandValidator : AbstractValidator<UpdateExpenseTypeCommand>
{
	public UpdateExpenseTypeCommandValidator()
	{
		RuleFor(x => x.Id)
			.GreaterThan(0).WithMessage("Geçerli bir masraf kategorisi ID'si girilmelidir.");

		RuleFor(x => x.Request.Name)
			.NotEmpty().WithMessage("Kategori adı boş olamaz.")
			.MaximumLength(100).WithMessage("Kategori adı en fazla 100 karakter olabilir.");

		RuleFor(x => x.Request.Description)
			.NotEmpty().WithMessage("Açıklama boş olamaz.")
			.MaximumLength(300).WithMessage("Açıklama en fazla 300 karakter olabilir.");
	}
}
