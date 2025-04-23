using FluentValidation;

namespace Expense.Application.Features.EmployeeAddresses.Commands.Update;

public class UpdateEmployeeAddressCommandValidator : AbstractValidator<UpdateEmployeeAddressCommand>
{
	public UpdateEmployeeAddressCommandValidator()
	{
		RuleFor(x => x.Id)
			.GreaterThan(0).WithMessage("Geçerli bir adres ID'si girilmelidir.");
	}
}