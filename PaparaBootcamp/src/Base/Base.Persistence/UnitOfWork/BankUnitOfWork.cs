using Base.Domain.Interfaces;
using Base.Persistence.DbContext;
using Base.Persistence.Repositories;
using Base.Persistence.UnitOfWork;

namespace Base.Persistence.UnitOfWork;

public class BankUnitOfWork : IBankUnitOfWork
{
	private readonly BankDbContext _context;

	public BankUnitOfWork(BankDbContext context)
	{
		_context = context;
	}

	public IBankRepository<T> Repository<T>() where T : class
	{
		return new BankRepository<T>(_context);
	}

	public async Task<int> CommitAsync()
	{
		return await _context.SaveChangesAsync();
	}

	public ITransaction BeginTransaction()
	{
		var transaction = _context.Database.BeginTransaction();
		return new EfTransaction(transaction);
	}

	public void Dispose()
	{
		_context.Dispose();
	}
}
