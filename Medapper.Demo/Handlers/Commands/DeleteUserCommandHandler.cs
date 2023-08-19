using Medapper.Demo.Contracts.Notifications;
using Medapper.Demo.Contracts.Requests;
using Medapper.Demo.Repositories;
using MediatR;

namespace Medapper.Demo.Handlers.Commands;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserRequest>
{
    private readonly IUserRepository _userRepository;
    private readonly IPublisher _publisher;

    public DeleteUserCommandHandler(IUserRepository userRepository, IPublisher publisher)
    {
        _userRepository = userRepository;
        _publisher = publisher;
    }

    public async Task Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        await _userRepository.DeleteAsync(request.Id, cancellationToken);
        
        await _publisher.Publish(new UserDeletedEvent
        {
            Message = $"User with id {request.Id} deleted."
        }, cancellationToken);
    }
}