using Papara.Wasm.Shared.Models.Expense.ExpenseTypes;

namespace Papara.Wasm.Shared.Models.Expense.Expenses;

public class ExpenseResponse
{
	public long Id { get; set; }
	public long EmployeeId { get; set; }
	public decimal Amount { get; set; }
	public bool Concluded { get; set; }
	public string Description { get; set; } = null!;
	public DateTimeOffset ExpenseDate { get; set; }
	public long ExpenseTypeId { get; set; }
	public ExpenseTypeResponse? ResponseExpenseType { get; set; }
}
