using Base.Application.Interfaces;
using Base.Domain.Entities;
using Base.Domain.Identity;
using Base.Domain.Interfaces;
using Base.Persistence.DbContext;
using Base.Persistence.Repositories;

namespace Base.Persistence.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
	private readonly AppDbContext _context;
	private readonly IUserContextService _userContextService;

	private Dictionary<Type, object> _repositories;

	public UnitOfWork(AppDbContext context, IUserContextService userContextService)
	{
		_context = context;
		_userContextService = userContextService;
		_repositories = new Dictionary<Type, object>();
	}

	public IRepository<T> Repository<T>() where T : BaseEntity
	{
		var type = typeof(T);
		if (!_repositories.ContainsKey(type))
		{
			var repositoryInstance = new GenericRepository<T>(_context, _userContextService);
			_repositories.Add(type, repositoryInstance);
		}
		return (IRepository<T>)_repositories[type];
	}

	public async Task<int> CommitAsync() => await _context.SaveChangesAsync();

	public void Dispose() => _context.Dispose();

}