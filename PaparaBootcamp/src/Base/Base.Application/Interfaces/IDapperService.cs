using System.Data;

namespace Base.Application.Interfaces;

public interface IDapperService
{
	Task<IEnumerable<T>> QueryAsync<T>(string sql, object? parameters = null, string? connectionName = null);
	Task<T?> QueryFirstOrDefaultAsync<T>(string sql, object? parameters = null, string? connectionName = null);
	IDbConnection CreateConnection(string? connectionName = null);
}
