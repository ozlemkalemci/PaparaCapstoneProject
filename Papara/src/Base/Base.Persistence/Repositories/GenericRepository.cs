using Microsoft.EntityFrameworkCore;
using Base.Application.Interfaces;
using Base.Domain.Entities;
using Base.Domain.Interfaces;
using Base.Persistence.DbContext;
using System.Linq.Expressions;

namespace Base.Persistence.Repositories;

public class GenericRepository<T> : IRepository<T> where T : BaseEntity
{
	protected readonly AppDbContext dbContext;
	protected readonly DbSet<T> dbSet;
	private readonly IUserContextService _userContextService;
	public GenericRepository(
		AppDbContext dbContext,
		IUserContextService userContextService)
	{
		this.dbContext = dbContext;
		this.dbSet = dbContext.Set<T>();
		_userContextService = userContextService;
	}

	public async Task<T> AddAsync(T entity)
	{
		entity.CreatedDate = DateTimeOffset.UtcNow;
		entity.CreatedById = _userContextService.GetCurrentUserId() ?? 0;
		entity.IsActive = true;

		await dbSet.AddAsync(entity);
		return entity;
	}

	public void Delete(T entity)
	{
		if (!entity.IsActive)
			return;

		entity.IsActive = false;
		entity.DeletedDate = DateTimeOffset.UtcNow;
		entity.DeletedById = _userContextService.GetCurrentUserId();

		dbContext.Set<T>().Update(entity);
	}

	public async Task DeleteByIdAsync(long id)
	{
		if (id <= 0)
			throw new ArgumentException("ID bulunamadı.");

		var entity = await dbContext.Set<T>().FindAsync(id);

		if (entity != null)
		{
			Delete(entity);
		}
		else
		{
			throw new KeyNotFoundException("Silinecek kayıt bulunamadı.");
		}
	}

	public async Task<List<T>> GetAllAsync(params string[] includes)
	{
		var query = dbSet.Where(e => e.IsActive).AsQueryable();
		query = includes.Aggregate(query, (current, include) => current.Include(include));
		return await query.ToListAsync();
	}

	public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null,
										   params Expression<Func<T, object>>[] includes)
	{
		var query = dbSet.AsQueryable();

		if (filter != null)
			query = query.Where(filter);

		if (includes != null && includes.Any())
		{
			foreach (var include in includes)
			{
				query = query.Include(include);
			}
		}

		return await query.ToListAsync();
	}

	public async Task<T?> GetByIdAsync(long id, params Expression<Func<T, object>>[] includes)
	{
		var query = dbSet.AsQueryable();

		if (includes != null && includes.Any())
		{
			foreach (var include in includes)
			{
				query = query.Include(include);
			}
		}

		return await query.FirstOrDefaultAsync(x => x.Id == id);
	}

	public void Update(T entity)
	{
		if (entity.Id <= 0)
			throw new ArgumentException("ID bulunamadı.");

		if (!entity.IsActive)
			throw new InvalidOperationException("Pasif bir kayıt güncellenemez.");

		entity.UpdatedDate = DateTimeOffset.UtcNow;
		entity.UpdatedById = _userContextService.GetCurrentUserId();
		dbSet.Update(entity);
	}

	public async Task<List<T>> Where(Expression<Func<T, bool>> predicate, params string[] includes)
	{
		var query = dbSet.Where(predicate).AsQueryable();
		query = includes.Aggregate(query, (current, include) => current.Include(include));
		return await query.ToListAsync();
	}
	public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
	{
		return await dbSet.AnyAsync(predicate);
	}

}