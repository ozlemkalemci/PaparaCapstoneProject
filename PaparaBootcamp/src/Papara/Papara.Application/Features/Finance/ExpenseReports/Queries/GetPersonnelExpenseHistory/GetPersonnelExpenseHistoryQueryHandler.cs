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
                    e.Id AS ExpenseId,
                    e.ExpenseDate,
                    e.Amount,
                    e.Description,
                    CAST(a.Status AS TINYINT) AS Status,
                    et.Name AS ExpenseType
                FROM Finance.Expenses e
                INNER JOIN Finance.ExpenseTypes et ON e.ExpenseTypeId = et.Id
                INNER JOIN Finance.ExpenseApprovals a ON e.Id = a.ExpenseId AND a.IsActive = 1
                WHERE e.EmployeeId = @EmployeeId AND e.IsActive = 1";

		var result = await _dapperService.QueryAsync<PersonnelExpenseReportResponse>(sql, new { request.EmployeeId });
		return result.ToList();
	}
}
