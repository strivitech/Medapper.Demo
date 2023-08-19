using Medapper.Demo.Contracts.Notifications;
using MediatR;

namespace Medapper.Demo.Handlers.Notifications;

public class UserDeletedEventHandler : INotificationHandler<UserDeletedEvent>
{
    public async Task Handle(UserDeletedEvent notification, CancellationToken cancellationToken)
    {
        await Task.Run(() => Console.WriteLine(notification.Message), cancellationToken);
    }
}