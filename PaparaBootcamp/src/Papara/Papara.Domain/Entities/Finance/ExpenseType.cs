using Base.Domain.Entities;

namespace Papara.Domain.Entities.Finance;

public class ExpenseType : BaseEntity
{
	public string Name { get; set; } = null!;
	public string Description { get; set; } = null!;
	public ICollection<Expense>? Expenses { get; set; }
}
