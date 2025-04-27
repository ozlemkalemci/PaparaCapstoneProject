using Base.Domain.Entities;

public class ExpenseAttachment : BaseEntity
{
	public long ExpenseId { get; set; }
	public string OriginalFileName { get; set; } = string.Empty; // Kullanıcının yüklediği isim
	public string StoredFileName { get; set; } = string.Empty;   // Sunucuda kaydedilen isim (GUID vs)
	public string ContentType { get; set; } = string.Empty;      // image/jpeg, application/pdf vs.
	public long FileSize { get; set; }
	public string FilePath { get; set; } = string.Empty;
	public string? Description { get; set; }

	public virtual Expense Expense { get; set; }
}
