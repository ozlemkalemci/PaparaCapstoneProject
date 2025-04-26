using FluentValidation;

namespace Papara.Application.Features.HR.EmployeeAddresses.Commands.Create;

public class CreateEmployeeAddressCommandValidator : AbstractValidator<CreateEmployeeAddressCommand>
{
	public CreateEmployeeAddressCommandValidator()
	{
		RuleFor(x => x.Request.City)
			.NotEmpty().WithMessage("Şehir boş olamaz.");

		RuleFor(x => x.Request.District)
			.NotEmpty().WithMessage("İlçe boş olamaz.");

		RuleFor(x => x.Request.Detail)
			.NotEmpty().WithMessage("Adres detayı boş olamaz.");

		RuleFor(x => x.Request.EmployeeId)
			.GreaterThan(0).WithMessage("Personel seçilmelidir.");
	}
}