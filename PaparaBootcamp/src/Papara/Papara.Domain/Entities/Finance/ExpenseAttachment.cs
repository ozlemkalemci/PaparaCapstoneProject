using Base.Domain.Entities;

namespace Papara.Domain.Entities.Finance;

public class ExpenseAttachment : BaseEntity
{
	public long ExpenseId { get; set; }
	public string FilePath { get; set; } = null!;
	public string FileName { get; set; } = null!;
	public string? Description { get; set; }

	public virtual Expense Expense { get; set; } = null!;
}