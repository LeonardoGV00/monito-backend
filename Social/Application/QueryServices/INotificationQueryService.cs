using MonitoNet.Backend.Social.Domain.Model.Aggregates;

namespace MonitoNet.Backend.Social.Application.QueryServices;

public interface INotificationQueryService
{
    Task<List<Notification>> GetAllAsync();
    Task<List<Notification>> GetByUserIdAsync(string userId);
}
