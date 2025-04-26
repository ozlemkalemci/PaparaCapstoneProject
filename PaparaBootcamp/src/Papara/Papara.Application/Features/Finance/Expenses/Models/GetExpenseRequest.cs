namespace Papara.Application.Features.Finance.Expenses.Models;

public class GetExpenseRequest
{
	public long? EmployeeId { get; set; }
	public long? ExpenseTypeId { get; set; }
	public bool IncludeEmployee { get; set; } = false;
	public bool IncludeExpenseType { get; set; } = false;
}
