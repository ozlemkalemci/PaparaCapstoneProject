namespace Papara.Application.Features.Finance.ExpenseTypes.Models;

public class ExpenseTypeResponse
{
	public long Id { get; set; }
	public string Name { get; set; } = null!;
	public string Description { get; set; } = null!;
}
