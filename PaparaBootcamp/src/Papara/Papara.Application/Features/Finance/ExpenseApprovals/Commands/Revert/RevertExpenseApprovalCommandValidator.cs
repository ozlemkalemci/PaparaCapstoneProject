using FluentValidation;

namespace Papara.Application.Features.Finance.ExpenseApprovals.Commands.Revert;

public class RevertExpenseApprovalCommandValidator : AbstractValidator<RevertExpenseApprovalCommand>
{
	public RevertExpenseApprovalCommandValidator()
	{
		RuleFor(x => x.Id)
			.GreaterThan(0)
			.WithMessage("Geçerli bir onay kaydı ID'si belirtilmelidir.");
	}
}
