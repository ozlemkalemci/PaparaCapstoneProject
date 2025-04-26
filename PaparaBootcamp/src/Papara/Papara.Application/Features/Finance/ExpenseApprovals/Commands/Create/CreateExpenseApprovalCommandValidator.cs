using FluentValidation;

namespace Papara.Application.Features.Finance.ExpenseApprovals.Commands.Create;

public class CreateExpenseApprovalCommandValidator : AbstractValidator<CreateExpenseApprovalCommand>
{
	public CreateExpenseApprovalCommandValidator()
	{
		RuleFor(x => x.Request.ExpenseId)
			.GreaterThan(0).WithMessage("Masraf kaydı seçilmelidir.");

		RuleFor(x => x.Request.Status)
			.IsInEnum().WithMessage("Geçerli bir masraf onay durumu seçiniz.");

		RuleFor(x => x.Request.Description)
			.NotEmpty().WithMessage("Açıklama boş olamaz.")
			.MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olmalıdır.");
	}
}
