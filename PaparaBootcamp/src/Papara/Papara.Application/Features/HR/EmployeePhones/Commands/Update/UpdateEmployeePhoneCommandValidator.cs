using FluentValidation;

namespace Papara.Application.Features.HR.EmployeePhones.Commands.Update;

public class UpdateEmployeePhoneCommandValidator : AbstractValidator<UpdateEmployeePhoneCommand>
{
	public UpdateEmployeePhoneCommandValidator()
	{
		RuleFor(x => x.Id)
			.GreaterThan(0).WithMessage("Geçerli bir telefon ID'si girilmelidir.");
	}
}