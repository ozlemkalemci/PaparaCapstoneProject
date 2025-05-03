namespace Papara.Application.Services.Approvals;

public class CreateAndTransferApprovalRequest
{
	public long ExpenseId { get; set; }
	public long CompanyId { get; set; }
	public string? Description { get; set; }
}
