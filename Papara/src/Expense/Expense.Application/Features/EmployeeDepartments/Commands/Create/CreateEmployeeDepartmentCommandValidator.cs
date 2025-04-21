using FluentValidation;

namespace Expense.Application.Features.EmployeeDepartments.Commands.Create;

public class CreateEmployeeDepartmentCommandValidator : AbstractValidator<CreateEmployeeDepartmentCommand>
{
	public CreateEmployeeDepartmentCommandValidator()
	{
		RuleFor(x => x.Request.DepartmentName)
			.NotEmpty().WithMessage("Departman adı boş olamaz.")
			.MaximumLength(100).WithMessage("Departman adı en fazla 100 karakter olabilir.");
	}
}