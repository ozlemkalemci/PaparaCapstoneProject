using FluentValidation;

namespace Papara.Application.Features.Corporation.Departments.Commands.Update;

public class UpdateDepartmentCommandValidator : AbstractValidator<UpdateDepartmentCommand>
{
	public UpdateDepartmentCommandValidator()
	{
		RuleFor(x => x.Request.DepartmentName)
			.NotEmpty().WithMessage("Departman adı boş olamaz.")
			.MaximumLength(100).WithMessage("Departman adı en fazla 100 karakter olabilir.");
	}
}