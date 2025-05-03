using Base.Domain.Interfaces;
using Papara.Application.Services.Banking.Models;
using Papara.Domain.Entities.Bank;

namespace Papara.Application.Services.Banking
{
	public class BankTransferSimulatorService : IBankTransferSimulatorService
	{
		private readonly IBankUnitOfWork _bankUnitOfWork;

		public BankTransferSimulatorService(IBankUnitOfWork bankUnitOfWork)
		{
			_bankUnitOfWork = bankUnitOfWork;
		}

		public async Task<BankTransferResult> TransferAsync(BankTransferRequest request)
		{
			using var transaction = _bankUnitOfWork.BeginTransaction();

			try
			{
				// random PaymentReferenceNumber üretme:
				var paymentReference = GeneratePaymentReference();

				var payment = new ExpensePayment
				{
					ExpenseId = request.ExpenseId ?? 0,
					Amount = request.Amount,
					PaymentDate = DateTimeOffset.UtcNow,
					IsSuccessful = true,
					PaymentReferenceNumber = paymentReference,
					SenderIBAN = request.SenderIBAN,
					ReceiverIBAN = request.ReceiverIBAN,
					TransferType = request.TransferType
				};

				await _bankUnitOfWork.Repository<ExpensePayment>().AddAsync(payment);
				await _bankUnitOfWork.CommitAsync();
				await transaction.CommitAsync();

				return new BankTransferResult
				{
					IsSuccessful = true,
					PaymentReferenceNumber = paymentReference
				};
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				return new BankTransferResult
				{
					IsSuccessful = false,
					ErrorMessage = $"Ödeme işlemi başarısız: {ex.Message}"
				};
			}
		}

		private static string GeneratePaymentReference()
		{
			var random = new Random();
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			return new string(Enumerable.Repeat(chars, 10)
			  .Select(s => s[random.Next(s.Length)]).ToArray());
		}
	}
}
