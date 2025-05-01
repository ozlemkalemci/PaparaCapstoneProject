using MediatR;
using Papara.Application.Features.Finance.ExpenseReports.Models;
using Papara.Domain.Enums.Finance;

namespace Papara.Application.Features.Finance.ExpenseReports.Queries.GetPersonnelSpendingSummary;

public class GetPersonnelSpendingSummaryQuery : IRequest<List<PersonnelSpendingSummaryResponse>>
{
	public ReportPeriod Period { get; set; } = ReportPeriod.Monthly;
}
