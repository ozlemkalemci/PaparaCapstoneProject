using System.ComponentModel.DataAnnotations;

namespace Papara.Domain.Enums.Finance;
public enum ReportPeriod : byte
{
	[Display(Name = "Günlük")]
	Daily,
	[Display(Name = "Haftalık")]
	Weekly,
	[Display(Name = "Aylık")]
	Monthly
}
