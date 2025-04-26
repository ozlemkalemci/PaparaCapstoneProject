namespace Papara.Application.Features.Finance.ExpenseTypes.Models;

public class CreateExpenseTypeRequest
{
	public string Name { get; set; } = null!;
	public string Description { get; set; } = null!;
}
