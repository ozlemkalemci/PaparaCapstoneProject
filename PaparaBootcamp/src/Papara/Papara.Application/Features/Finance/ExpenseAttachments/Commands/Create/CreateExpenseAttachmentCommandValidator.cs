using FluentValidation;
using Papara.Application.Features.Finance.ExpenseAttachments.Commands.Create;

namespace Papara.Application.Features.Finance.ExpenseAttachments.Validators;

public class CreateExpenseAttachmentCommandValidator : AbstractValidator<CreateExpenseAttachmentCommand>
{
	public CreateExpenseAttachmentCommandValidator()
	{
		RuleFor(x => x.ExpenseId)
			.GreaterThan(0)
			.WithMessage("Geçerli bir masraf kaydı seçilmelidir.");

		RuleFor(x => x.File)
			.NotNull()
			.WithMessage("Dosya seçilmelidir.")
			.Must(file => file != null && file.Length > 0)
			.WithMessage("Boş bir dosya yüklenemez.")
			.Must(file => file.Length <= 5 * 1024 * 1024) // 5 MB sınırı
			.WithMessage("Dosya boyutu 5 MB'ı geçemez.");

		RuleFor(x => x.File.ContentType)
			.NotEmpty()
			.Must(contentType =>
				contentType == "application/pdf" ||
				contentType.StartsWith("image/"))
			.WithMessage("Sadece PDF veya görsel dosyalar yüklenebilir.");

	}
}
