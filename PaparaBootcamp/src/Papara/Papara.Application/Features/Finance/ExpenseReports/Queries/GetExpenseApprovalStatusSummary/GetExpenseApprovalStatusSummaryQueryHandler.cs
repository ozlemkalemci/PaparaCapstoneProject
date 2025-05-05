using Base.Application.Common.Extensions;
using Base.Application.Interfaces;
using MediatR;
using Papara.Application.Features.Finance.ExpenseReports.Models;

namespace Papara.Application.Features.Finance.ExpenseReports.Queries.GetExpenseApprovalStatusSummary;

// Karşılanan ihtiyaç: 
// Şirket günlük haftalık aylık onaylanan ve red edilen masraf miktarlarını raporlayabilmeli.

public class GetExpenseApprovalStatusSummaryQueryHandler : IRequestHandler<GetExpenseApprovalStatusSummaryQuery, List<ExpenseApprovalStatusSummaryResponse>>
{
	private readonly IDapperService _dapperService;

	public GetExpenseApprovalStatusSummaryQueryHandler(IDapperService dapperService)
	{
		_dapperService = dapperService;
	}

	public async Task<List<ExpenseApprovalStatusSummaryResponse>> Handle(GetExpenseApprovalStatusSummaryQuery request, CancellationToken cancellationToken)
	{
		string sql = "EXEC sp_GetExpenseApprovalStatusSummary @Period";
		var result = await _dapperService.QueryAsync<ExpenseApprovalStatusSummaryResponse>(sql, new { Period = request.Period.ToString().ToLower() });
		return result.ToList();
	}
}
