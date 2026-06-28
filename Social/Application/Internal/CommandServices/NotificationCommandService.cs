using MonitoNet.Backend.Social.Application.CommandServices;
using MonitoNet.Backend.Social.Domain.Model.Aggregates;
using MonitoNet.Backend.Social.Domain.Repositories;

namespace MonitoNet.Backend.Social.Application.Internal.CommandServices;

public sealed class NotificationCommandService : INotificationCommandService
{
    private readonly INotificationRepository _notifications;

    public NotificationCommandService(INotificationRepository notifications)
    {
        _notifications = notifications;
    }

    public Task CreateAsync(Notification notification) => _notifications.CreateAsync(notification);
}
