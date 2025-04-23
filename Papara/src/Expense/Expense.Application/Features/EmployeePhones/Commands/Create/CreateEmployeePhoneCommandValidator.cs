using FluentValidation;

namespace Expense.Application.Features.EmployeePhones.Commands.Create;


public class CreateEmployeePhoneCommandValidator : AbstractValidator<CreateEmployeePhoneCommand>
{
	public CreateEmployeePhoneCommandValidator()
	{
		RuleFor(x => x.Request.EmployeeId)
			.GreaterThan(0).WithMessage("Geçerli bir telefon ID'si belirtilmelidir.");

		RuleFor(x => x.Request.PhoneNumber)
			.NotEmpty().WithMessage("Telefon numarası boş olamaz.")
			.Matches(@"^\d{10}$")
			.WithMessage("Telefon numarası 10 haneli ve sadece rakamlardan oluşmalıdır. Başında '0' olmadan giriniz (örn: 5XXXXXXXXX).")
			.WithName("Telefon Numarası");

		RuleFor(x => x.Request.Type)
			.IsInEnum()
			.WithMessage("Geçerli bir telefon tipi seçiniz (Mobil, Ev, İş).");
	}
}