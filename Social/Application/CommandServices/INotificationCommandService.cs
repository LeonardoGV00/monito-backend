using MonitoNet.Backend.Social.Domain.Model.Aggregates;

namespace MonitoNet.Backend.Social.Application.CommandServices;

public interface INotificationCommandService
{
    Task CreateAsync(Notification notification);
}
