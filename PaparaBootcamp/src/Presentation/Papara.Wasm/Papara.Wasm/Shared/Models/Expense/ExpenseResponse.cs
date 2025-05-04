namespace Papara.Wasm.Shared.Models.Expense;

public class ExpenseResponse
{
	public long Id { get; set; }
	public long EmployeeId { get; set; }
	public decimal Amount { get; set; }
	public string Description { get; set; } = null!;
	public DateTimeOffset ExpenseDate { get; set; }
	public long ExpenseTypeId { get; set; }
	public ExpenseTypeResponse? ResponseExpenseType { get; set; }
}
