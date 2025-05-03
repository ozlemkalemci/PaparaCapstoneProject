using MediatR;
using Papara.Application.Features.Bank.BankAccounts.Models;

namespace Papara.Application.Features.Bank.BankAccounts.Queries.GetAll;

public class GetAllBankAccountsQuery : IRequest<List<BankAccountResponse>> 
{
}