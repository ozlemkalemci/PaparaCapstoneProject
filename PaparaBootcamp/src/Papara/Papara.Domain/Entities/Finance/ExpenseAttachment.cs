using Base.Domain.Entities;

namespace Papara.Domain.Entities.Finance;

public class ExpenseAttachment : BaseEntity
{
	public long ExpenseId { get; set; }
	public Expense Expense { get; set; } = null!;
	public string FilePath { get; set; } = null!;
}
