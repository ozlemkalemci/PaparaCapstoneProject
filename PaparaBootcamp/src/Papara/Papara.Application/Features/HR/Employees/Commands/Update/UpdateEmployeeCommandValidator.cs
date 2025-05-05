using FluentValidation;

namespace Papara.Application.Features.HR.Employees.Commands.Update;

public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
{
	public UpdateEmployeeCommandValidator()
	{
		RuleFor(x => x.Id)
			.GreaterThan(0).WithMessage("Geçerli bir çalışan ID'si girilmelidir.");

	}
}