using Base.Application.Common.Extensions;
using Base.Application.Interfaces;
using MediatR;
using Papara.Application.Features.Finance.ExpenseReports.Models;

namespace Papara.Application.Features.Finance.ExpenseReports.Queries.GetAdminExpenseSummaryReport;

// Karşılanan ihtiyaç: 
// Şirket günlük haftalık ve aylık raporlar ile ödeme yoğunluğu raporlanmalı.

public class GetAdminExpenseSummaryReportQueryHandler : IRequestHandler<GetAdminExpenseSummaryReportQuery, List<AdminExpenseSummaryResponse>>
{
	private readonly IDapperService _dapperService;

	public GetAdminExpenseSummaryReportQueryHandler(IDapperService dapperService)
	{
		_dapperService = dapperService;
	}

	public async Task<List<AdminExpenseSummaryResponse>> Handle(GetAdminExpenseSummaryReportQuery request, CancellationToken cancellationToken)
	{
		string sql = "EXEC sp_GetAdminExpenseSummaryReport @Period";
		var result = await _dapperService.QueryAsync<AdminExpenseSummaryResponse>(sql, new { Period = request.Period.GetDisplayName().ToLower() });
		return result.ToList();
	}

}
