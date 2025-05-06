namespace Papara.Wasm.Shared.Models.Expense.ExpenseApprovals
{
	public class CreateAndTransferApprovalRequest
	{
		public long ExpenseId { get; set; }
		public long CompanyId { get; set; }
		public string? Description { get; set; }
	}
}
