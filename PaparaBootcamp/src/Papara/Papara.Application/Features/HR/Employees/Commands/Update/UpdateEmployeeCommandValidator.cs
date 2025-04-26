using FluentValidation;

namespace Papara.Application.Features.HR.Employees.Commands.Update;

public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
{
	public UpdateEmployeeCommandValidator()
	{
		RuleFor(x => x.Id)
			.GreaterThan(0).WithMessage("Geçerli bir çalışan ID'si girilmelidir.");

		RuleFor(x => x.Request.Email)
			.NotEmpty().WithMessage("E-posta boş olamaz.")
			.EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

		RuleFor(x => x.Request.DepartmentId)
			.GreaterThan(0).WithMessage("Departman seçilmelidir.");
	}
}