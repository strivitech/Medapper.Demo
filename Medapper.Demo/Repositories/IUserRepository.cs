using Medapper.Demo.Data;

namespace Medapper.Demo.Repositories;

public interface IUserRepository
{
    Task<User> GetAsync(Guid id, CancellationToken cancellationToken = default);

    Task<User> CreateAsync(User user, CancellationToken cancellationToken = default);

    Task<User> UpdateAsync(User user, CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}