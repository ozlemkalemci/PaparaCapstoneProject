using Papara.Application.Features.HR.Employees.Models;
using Papara.Application.Features.Finance.ExpenseTypes.Models;
using Papara.Application.Features.Finance.ExpenseApprovals.Models;
using Papara.Domain.Enums.Finance;

namespace Papara.Application.Features.Finance.Expenses.Models;

public class ExpenseResponse
{
	public long Id { get; set; }
	public long EmployeeId { get; set; }
	public decimal Amount { get; set; }
	public string Description { get; set; } = null!;
	public DateTimeOffset ExpenseDate { get; set; }
	public long ExpenseTypeId { get; set; }
	public bool Concluded { get; set; }
	public string? Location { get; set; }
	public PaymentMethod PaymentMethod { get; set; }
	public EmployeeResponse? ResponseEmployee { get; set; }
	public ExpenseTypeResponse? ResponseExpenseType { get; set; }
	public ExpenseApprovalResponse? ResponseExpenseApproval { get; set; }
}
