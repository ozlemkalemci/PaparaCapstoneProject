using FluentValidation;

namespace Papara.Application.Features.Corporation.Departments.Commands.Create;

public class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
{
	public CreateDepartmentCommandValidator()
	{
		RuleFor(x => x.Request.DepartmentName)
			.NotEmpty().WithMessage("Departman adı boş olamaz.")
			.MaximumLength(100).WithMessage("Departman adı en fazla 100 karakter olabilir.");
	}
}