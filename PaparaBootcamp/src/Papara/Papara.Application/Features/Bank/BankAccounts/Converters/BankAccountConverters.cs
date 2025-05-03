using Papara.Application.Features.Bank.BankAccounts.Models;
using Papara.Domain.Entities.Bank;

namespace Papara.Application.Features.Bank.BankAccounts.Converters;

public static class BankAccountConverters
{
	public static BankAccountResponse BankAccountConverter(BankAccount entity)
	{
		return new BankAccountResponse
		{
			Id = entity.Id,
			AccountHolderName = entity.AccountHolderName,
			IBAN = entity.IBAN,
			IdentityNumber = entity.IdentityNumber,
			TaxNumber = entity.TaxNumber,
			AccountType = entity.AccountType
		};
	}

	public static List<BankAccountResponse> BankAccountConverterList(List<BankAccount> entities)
	{
		if (entities == null || entities.Count == 0)
			return new List<BankAccountResponse>();

		return entities.Select(BankAccountConverter).ToList();
	}
}
