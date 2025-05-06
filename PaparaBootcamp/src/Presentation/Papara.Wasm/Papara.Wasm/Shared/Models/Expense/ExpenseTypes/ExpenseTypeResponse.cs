namespace Papara.Wasm.Shared.Models.Expense.ExpenseTypes;

public class ExpenseTypeResponse
{
	public long Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
}