namespace Papara.Application.Features.Finance.Expenses.Models;

public class CreateExpenseRequest
{
	public long EmployeeId { get; set; }
	public long ExpenseTypeId { get; set; }
	public decimal Amount { get; set; }
	public string Description { get; set; } = null!;
	public DateTimeOffset ExpenseDate { get; set; }
}
