using MediatR;
using Papara.Application.Features.Finance.ExpenseReports.Models;

namespace Papara.Application.Features.Finance.ExpenseReports.Queries.GetPersonnelExpenseHistory;

public class GetPersonnelExpenseHistoryQuery : IRequest<List<PersonnelExpenseReportResponse>>
{
	public long EmployeeId { get; set; }
}
