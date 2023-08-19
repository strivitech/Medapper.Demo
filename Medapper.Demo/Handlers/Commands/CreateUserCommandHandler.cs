using Medapper.Demo.Contracts.Notifications;
using Medapper.Demo.Contracts.Requests;
using Medapper.Demo.Data;
using Medapper.Demo.Repositories;
using MediatR;

namespace Medapper.Demo.Handlers.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserRequest>
{
    private readonly IUserRepository _userRepository;
    private readonly IPublisher _publisher;

    public CreateUserCommandHandler(IUserRepository userRepository, IPublisher publisher)
    {
        _userRepository = userRepository;
        _publisher = publisher;
    }

    public async Task Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Name = request.Name
        };
        await _userRepository.CreateAsync(user, cancellationToken);
        await _publisher.Publish(new UserCreatedEvent
        {
            Message = $"User with id {user.Id} and name {user.Name} created."
        }, cancellationToken);
    }
}