using Base.Application.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Base.Infrastructure.Services.Dapper;

public class DapperService : IDapperService
{
	private readonly IConfiguration _configuration;

	public DapperService(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	public IDbConnection CreateConnection(string? connectionName = null)
	{
		var connStr = _configuration.GetConnectionString(connectionName ?? "PaparaSqlConnection");
		return new SqlConnection(connStr);
	}

	public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? parameters = null, string? connectionName = null)
	{
		using var connection = CreateConnection(connectionName);
		return await connection.QueryAsync<T>(sql, parameters);
	}

	public async Task<T?> QueryFirstOrDefaultAsync<T>(string sql, object? parameters = null, string? connectionName = null)
	{
		using var connection = CreateConnection(connectionName);
		return await connection.QueryFirstOrDefaultAsync<T>(sql, parameters);
	}
}
