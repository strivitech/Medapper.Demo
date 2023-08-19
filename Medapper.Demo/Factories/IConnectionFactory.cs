using System.Data;
using Medapper.Demo.Settings;
using Microsoft.Extensions.Options;
using Npgsql;

namespace Medapper.Demo.Factories;

public interface IConnectionFactory
{
    IDbConnection Create();
}

public class PostgresConnectionFactory : IConnectionFactory
{
    private readonly DbConnectionSettings _settings;
    
    public PostgresConnectionFactory(IOptions<DbConnectionSettings> options) 
    {
        _settings = options.Value ?? throw new InvalidOperationException("DbConnectionSettings is null");
    }
    
    public IDbConnection Create()
    {
        return new NpgsqlConnection(_settings.ConnectionString);
    }
}