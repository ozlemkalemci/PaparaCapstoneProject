using Base.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace Base.Persistence.UnitOfWork;

public class EfTransaction : ITransaction
{
	private readonly IDbContextTransaction _transaction;

	public EfTransaction(IDbContextTransaction transaction)
	{
		_transaction = transaction;
	}

	public async Task CommitAsync()
	{
		await _transaction.CommitAsync();
	}

	public async Task RollbackAsync()
	{
		await _transaction.RollbackAsync();
	}

	public void Dispose()
	{
		_transaction.Dispose();
	}
}