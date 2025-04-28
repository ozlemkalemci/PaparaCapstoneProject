using System.Linq.Expressions;

namespace Base.Domain.Interfaces;

public interface IBankRepository<T> where T : class
{
	Task<T?> GetByIdAsync(long id);
	Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
	Task AddAsync(T entity);
	void Update(T entity);
	void Delete(T entity);
}
