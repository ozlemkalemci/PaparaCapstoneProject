using FluentValidation;

namespace Papara.Application.Features.Finance.Expenses.Commands.Create;

public class CreateExpenseCommandValidator : AbstractValidator<CreateExpenseCommand>
{
	public CreateExpenseCommandValidator()
	{
		RuleFor(x => x.Request.EmployeeId)
			.GreaterThan(0).WithMessage("Çalışan seçilmelidir.");

		RuleFor(x => x.Request.ExpenseTypeId)
			.GreaterThan(0).WithMessage("Masraf türü seçilmelidir.");

		RuleFor(x => x.Request.Amount)
			.GreaterThan(0).WithMessage("Tutar 0'dan büyük olmalıdır.");

		RuleFor(x => x.Request.Description)
			.NotEmpty().WithMessage("Açıklama boş olamaz.");

		RuleFor(x => x.Request.ExpenseDate)
			.NotEmpty().WithMessage("Masraf tarihi belirtilmelidir.");
	}
}
