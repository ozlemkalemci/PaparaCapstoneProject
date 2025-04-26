using FluentValidation;

namespace Papara.Application.Features.Finance.Expenses.Commands.Update;

public class UpdateExpenseCommandValidator : AbstractValidator<UpdateExpenseCommand>
{
	public UpdateExpenseCommandValidator()
	{
		RuleFor(x => x.Id)
			.GreaterThan(0).WithMessage("Geçerli bir masraf ID'si girilmelidir.");

		RuleFor(x => x.Request.Amount)
			.GreaterThan(0).WithMessage("Tutar 0'dan büyük olmalıdır.");

		RuleFor(x => x.Request.Description)
			.NotEmpty().WithMessage("Açıklama boş olamaz.");

		RuleFor(x => x.Request.ExpenseDate)
			.NotEmpty().WithMessage("Masraf tarihi belirtilmelidir.");

		RuleFor(x => x.Request.ExpenseTypeId)
			.GreaterThan(0).WithMessage("Masraf türü seçilmelidir.");
	}
}
