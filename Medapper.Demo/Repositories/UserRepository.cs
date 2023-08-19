using Dapper;
using Medapper.Demo.Data;
using Medapper.Demo.Factories;

namespace Medapper.Demo.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IConnectionFactory _connectionFactory;

    public UserRepository(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<User> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        using var connection = _connectionFactory.Create();
        return await connection.QueryFirstOrDefaultAsync<User>("SELECT * FROM Users WHERE Id = @id", new { id });
    }

    public async Task<User> CreateAsync(User user, CancellationToken cancellationToken = default)
    {
        using var connection = _connectionFactory.Create();
        user.Id = Guid.NewGuid();
        await connection.ExecuteAsync("INSERT INTO Users (Id, Name) VALUES (@Id, @Name)", user);
        return user;
    }

    public async Task<User> UpdateAsync(User user, CancellationToken cancellationToken = default)
    {
        using var connection = _connectionFactory.Create();
        await connection.ExecuteAsync("UPDATE Users SET Name = @Name WHERE Id = @Id", user);
        return user;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        using var connection = _connectionFactory.Create();
        await connection.ExecuteAsync("DELETE FROM Users WHERE Id = @id", new { id });
    }
}