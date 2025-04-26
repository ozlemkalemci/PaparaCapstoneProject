namespace Base.Domain.Interfaces;

public interface ITransaction : IDisposable
{
	Task CommitAsync();
	Task RollbackAsync();
}