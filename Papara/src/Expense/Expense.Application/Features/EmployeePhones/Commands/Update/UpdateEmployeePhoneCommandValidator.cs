using FluentValidation;

namespace Expense.Application.Features.EmployeePhones.Commands.Update;

public class UpdateEmployeePhoneCommandValidator : AbstractValidator<UpdateEmployeePhoneCommand>
{
	public UpdateEmployeePhoneCommandValidator()
	{
		RuleFor(x => x.Id)
			.GreaterThan(0).WithMessage("Geçerli bir telefon ID'si girilmelidir.");
	}
}