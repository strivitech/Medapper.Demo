using Medapper.Demo.Contracts.Notifications;
using MediatR;

namespace Medapper.Demo.Handlers.Notifications;

public class UserCreatedEventHandler : INotificationHandler<UserCreatedEvent>
{
    public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
    {
        await Task.Run(() => Console.WriteLine(notification.Message), cancellationToken);
    }
}