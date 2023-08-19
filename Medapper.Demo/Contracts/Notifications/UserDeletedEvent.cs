using MediatR;

namespace Medapper.Demo.Contracts.Notifications;

public class UserDeletedEvent : INotification
{
    public string Message { get; set; } = null!;
}