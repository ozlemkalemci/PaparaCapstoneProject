namespace Base.Domain.Interfaces;

public interface IBankUnitOfWork : IDisposable
{
	IBankRepository<T> Repository<T>() where T : class;
	Task<int> CommitAsync();
	ITransaction BeginTransaction();
}
