using MonitoNet.Backend.Social.Domain.Model.Aggregates;

namespace MonitoNet.Backend.Social.Domain.Repositories;

public interface INotificationRepository
{
    Task<List<Notification>> GetAllAsync();
    Task<List<Notification>> GetByUserIdAsync(string userId);
    Task CreateAsync(Notification notification);
}
