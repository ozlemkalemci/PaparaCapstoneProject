using Base.Application.Interfaces;
using MediatR;
using Papara.Application.Features.Finance.ExpenseReports.Models;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Papara.Application.Features.Finance.ExpenseReports.Queries.GetPersonnelExpenseHistory;

// Karşılanan ihtiyaç:
// Personelin kendi işlem hareketleri için bir rapor geliştirilmeli.

public class GetPersonnelExpenseHistoryQueryHandler : IRequestHandler<GetPersonnelExpenseHistoryQuery, List<PersonnelExpenseReportResponse>>
{
	private readonly IDapperService _dapperService;

	public GetPersonnelExpenseHistoryQueryHandler(IDapperService dapperService)
	{
		_dapperService = dapperService;
	}

	public async Task<List<PersonnelExpenseReportResponse>> Handle(GetPersonnelExpenseHistoryQuery request, CancellationToken cancellationToken)
	{
		const string sql = @"
			SELECT 
				ExpenseId,
				ExpenseDate,
				Amount,
				Description,
				CAST(ApprovalStatus AS TINYINT) AS Status,
				ExpenseType
			FROM vw_PersonnelExpenseHistory
			WHERE EmployeeId = @EmployeeId";

		var result = await _dapperService.QueryAsync<PersonnelExpenseReportResponse>(sql, new { request.EmployeeId });
		return result.ToList();
	}
}
