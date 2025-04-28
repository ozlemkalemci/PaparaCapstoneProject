using Base.Domain.Interfaces;
using Base.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Base.Persistence.Repositories
{
	public class BankRepository<T> : IBankRepository<T> where T : class
	{
		private readonly BankDbContext _context;
		private readonly DbSet<T> _dbSet;

		public BankRepository(BankDbContext context)
		{
			_context = context;
			_dbSet = context.Set<T>();
		}

		public async Task<T?> GetByIdAsync(long id)
		{
			return await _dbSet.FindAsync(id);
		}

		public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
		{
			if (filter != null)
				return await _dbSet.Where(filter).ToListAsync();

			return await _dbSet.ToListAsync();
		}

		public async Task AddAsync(T entity)
		{
			await _dbSet.AddAsync(entity);
		}

		public void Update(T entity)
		{
			_dbSet.Update(entity);
		}

		public void Delete(T entity)
		{
			_dbSet.Remove(entity);
		}
	}
}
