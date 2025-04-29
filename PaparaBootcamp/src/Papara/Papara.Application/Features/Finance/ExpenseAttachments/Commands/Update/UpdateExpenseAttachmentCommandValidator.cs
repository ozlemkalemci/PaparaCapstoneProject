using FluentValidation;

namespace Papara.Application.Features.Finance.ExpenseAttachments.Commands.Update;

public class UpdateExpenseAttachmentCommandValidator : AbstractValidator<UpdateExpenseAttachmentCommand>
{
	public UpdateExpenseAttachmentCommandValidator()
	{
		RuleFor(x => x.Id)
			.GreaterThan(0)
			.WithMessage("Geçerli bir dosya ID'si girilmelidir.");

		RuleFor(x => x.Request.File)
			.NotNull()
			.WithMessage("Dosya seçilmelidir.")
			.Must(file => file != null && file.Length > 0)
			.WithMessage("Boş bir dosya yüklenemez.")
			.Must(file => file.Length <= 5 * 1024 * 1024) // 5 MB sınırı koyduk
			.WithMessage("Dosya boyutu 5 MB'ı geçemez.");

		RuleFor(x => x.Request.File.ContentType)
			.NotEmpty()
			.Must(contentType =>
				contentType == "application/pdf" ||
				contentType.StartsWith("image/"))
			.WithMessage("Sadece PDF veya görsel dosyalar yüklenebilir.");
	}
}
