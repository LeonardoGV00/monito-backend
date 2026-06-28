using MonitoNet.Backend.Social.Application.QueryServices;
using MonitoNet.Backend.Social.Domain.Model.Aggregates;
using MonitoNet.Backend.Social.Domain.Repositories;

namespace MonitoNet.Backend.Social.Application.Internal.QueryServices;

public sealed class NotificationQueryService : INotificationQueryService
{
    private readonly INotificationRepository _notifications;

    public NotificationQueryService(INotificationRepository notifications)
    {
        _notifications = notifications;
    }

    public Task<List<Notification>> GetAllAsync() => _notifications.GetAllAsync();
    public Task<List<Notification>> GetByUserIdAsync(string userId) => _notifications.GetByUserIdAsync(userId);
}
