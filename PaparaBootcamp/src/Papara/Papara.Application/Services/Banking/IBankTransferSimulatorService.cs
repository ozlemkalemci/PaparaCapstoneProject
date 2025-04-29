using System.Threading.Tasks;
using Papara.Application.Services.Banking.Models;

namespace Papara.Application.Services.Banking;

public interface IBankTransferSimulatorService
{
	Task<BankTransferResult> TransferAsync(BankTransferRequest request);

}
