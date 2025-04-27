using Papara.Application.Features.Finance.ExpenseAttachments.Models;
using Papara.Application.Features.Finance.Expenses.Converters;
using Papara.Domain.Entities.Finance;

namespace Papara.Application.Features.Finance.ExpenseAttachments.Converters;

public static class ExpenseAttachmentConverters
{
	public static ExpenseAttachmentResponse ExpenseAttachmentConverter(ExpenseAttachment item)
	{
		return new ExpenseAttachmentResponse
		{
			Id = item.Id,
			ExpenseId = item.ExpenseId,
			OriginalFileName = item.OriginalFileName,
			StoredFileName = item.StoredFileName,
			ContentType = item.ContentType,
			FileSize = item.FileSize,
			FilePath = item.FilePath,
			Description = item.Description,

			ResponseExpense = item.Expense == null ? null :
				ExpenseConverters.ExpenseConverter(item.Expense)
		};
	}

	public static List<ExpenseAttachmentResponse> ExpenseAttachmentConverterList(List<ExpenseAttachment> items)
	{
		if (items == null || items.Count == 0)
			return new List<ExpenseAttachmentResponse>();

		var responseDto = (from item in items select ExpenseAttachmentConverter(item)).ToList();
		return responseDto;
	}
}
