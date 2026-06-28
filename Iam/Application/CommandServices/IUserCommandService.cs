using MonitoNet.Backend.Iam.Domain.Model.Commands;

namespace MonitoNet.Backend.Iam.Application.CommandServices;

public interface IUserCommandService
{
    Task<bool> FollowAsync(string targetUserId, FollowUserCommand command);
}
