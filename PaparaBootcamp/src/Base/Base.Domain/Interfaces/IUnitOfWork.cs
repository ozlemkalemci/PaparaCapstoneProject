using Base.Domain.Entities;
using Base.Domain.Identity;

namespace Base.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
	IRepository<T> Repository<T>() where T : BaseEntity;
	Task<int> CommitAsync();
	ITransaction BeginTransaction();
}