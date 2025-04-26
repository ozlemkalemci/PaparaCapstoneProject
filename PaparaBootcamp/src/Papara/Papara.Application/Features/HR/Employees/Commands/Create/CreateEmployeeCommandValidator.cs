using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papara.Application.Features.HR.Employees.Commands.Create;

public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
	public CreateEmployeeCommandValidator()
	{
		RuleFor(x => x.Request.Email)
			.NotEmpty().WithMessage("E-posta boş olamaz.")
			.EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

		RuleFor(x => x.Request.FirstName)
			.NotEmpty().WithMessage("Ad boş olamaz.");

		RuleFor(x => x.Request.LastName)
			.NotEmpty().WithMessage("Soyad boş olamaz.");

		RuleFor(x => x.Request.IdentityNumber)
			.NotEmpty().WithMessage("TC Kimlik numarası boş olamaz.")
			.Length(11).WithMessage("TC Kimlik numarası 11 haneli olmalıdır.");

		RuleFor(x => x.Request.IBAN)
			.NotEmpty().WithMessage("IBAN boş olamaz.")
			.MinimumLength(16).WithMessage("Geçerli bir IBAN giriniz.");

		RuleFor(x => x.Request.DepartmentId)
			.GreaterThan(0).WithMessage("Departman seçilmelidir.");
	}
}