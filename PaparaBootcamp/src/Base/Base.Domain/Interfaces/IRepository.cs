using Base.Domain.Entities;
using System.Linq.Expressions;

namespace Base.Domain.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
	Task<T?> GetByIdAsync(long id, params Expression<Func<T, object>>[] includes);
	Task<T?> GetByIdAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);
	Task<List<T>> GetAllAsync(params string[] includes);
	Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includes);
	Task<List<T>> Where(Expression<Func<T, bool>> predicate, params string[] includes);
	Task<T> AddAsync(T entity);
	void Update(T entity);
	void Delete(T entity);
	Task DeleteByIdAsync(long id);
	Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

}