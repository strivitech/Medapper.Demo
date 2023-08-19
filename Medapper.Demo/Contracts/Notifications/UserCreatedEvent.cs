using MediatR;

namespace Medapper.Demo.Contracts.Notifications;

public class UserCreatedEvent : INotification
{
    public string Message { get; set; } = null!;
}