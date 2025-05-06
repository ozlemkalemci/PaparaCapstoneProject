using Papara.Domain.Enums.Finance;

namespace Papara.Application.Features.Finance.Expenses.Models;

public class GetExpenseRequest
{
	public bool? Concluded { get; set; } = null;
	public long? EmployeeId { get; set; }
	public long? ExpenseTypeId { get; set; }
	public DateTimeOffset? StartDate { get; set; }
	public DateTimeOffset? EndDate { get; set; }
	public PaymentMethod PaymentMethod { get; set; }
	public bool IncludeEmployee { get; set; } = false;
	public bool IncludeExpenseType { get; set; } = false;
}
