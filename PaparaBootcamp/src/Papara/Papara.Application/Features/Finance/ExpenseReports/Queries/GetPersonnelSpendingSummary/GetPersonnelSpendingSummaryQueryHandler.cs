using Base.Application.Common.Extensions;
using Base.Application.Interfaces;
using MediatR;
using Papara.Application.Features.Finance.ExpenseReports.Models;

namespace Papara.Application.Features.Finance.ExpenseReports.Queries.GetPersonnelSpendingSummary;

// Karşılanan ihtiyaç: 
// Şirket personel bazlı günlük haftalık ve aylık harcama yoğunluğunu raporlayabilmeli.

public class GetPersonnelSpendingSummaryQueryHandler : IRequestHandler<GetPersonnelSpendingSummaryQuery, List<PersonnelSpendingSummaryResponse>>
{
	private readonly IDapperService _dapperService;

	public GetPersonnelSpendingSummaryQueryHandler(IDapperService dapperService)
	{
		_dapperService = dapperService;
	}

	public async Task<List<PersonnelSpendingSummaryResponse>> Handle(GetPersonnelSpendingSummaryQuery request, CancellationToken cancellationToken)
	{
		string sql = "EXEC sp_GetPersonnelSpendingSummary @Period";
		var result = await _dapperService.QueryAsync<PersonnelSpendingSummaryResponse>(sql, new { Period = request.Period.ToString().ToLower() });
		return result.ToList();
	}
}
