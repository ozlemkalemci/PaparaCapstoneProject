using Papara.Application.Features.Finance.ExpenseApprovals.Models;
using Papara.Application.Services.Approvals;

namespace Papara.Application.Services.Finance.Approvals;

public interface IExpenseApprovalService
{
	Task<ExpenseApprovalResponse> CreateAndTransferApprovalAsync(CreateAndTransferApprovalRequest request);

}
