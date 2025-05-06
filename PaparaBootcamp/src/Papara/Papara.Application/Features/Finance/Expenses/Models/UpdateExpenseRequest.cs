using Papara.Domain.Enums.Finance;

namespace Papara.Application.Features.Finance.Expenses.Models;

public class UpdateExpenseRequest
{
	public decimal Amount { get; set; }
	public string Description { get; set; } = null!;
	public DateTimeOffset ExpenseDate { get; set; }
	public long ExpenseTypeId { get; set; }
	public bool IsActive { get; set; }
	public bool Concluded { get; set; }
}
