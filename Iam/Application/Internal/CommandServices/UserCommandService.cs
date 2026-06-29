using MonitoNet.Backend.Iam.Application.CommandServices;
using MonitoNet.Backend.Iam.Domain.Model.Commands;
using MonitoNet.Backend.Iam.Domain.Repositories;
using MonitoNet.Backend.Social.Application.CommandServices;
using MonitoNet.Backend.Social.Domain.Model.Aggregates;
using MonitoNet.Backend.Social.Domain.Model.Enums;

namespace MonitoNet.Backend.Iam.Application.Internal.CommandServices;

public sealed class UserCommandService : IUserCommandService
{
    private readonly IUserRepository _users;
    private readonly INotificationCommandService _notifications;

    public UserCommandService(IUserRepository users, INotificationCommandService notifications)
    {
        _users = users;
        _notifications = notifications;
    }

    public async Task<bool> FollowAsync(string targetUserId, FollowUserCommand command)
    {
        var targetUser = await _users.GetByIdAsync(targetUserId);
        var followerUser = await _users.GetByIdAsync(command.FollowerUserId);

        if (targetUser is null || followerUser is null)
        {
            return false;
        }

        var updated = await _users.IncrementFollowersAsync(targetUserId);
        if (!updated)
        {
            return false;
        }

        await _notifications.CreateAsync(new Notification
        {
            UsuarioId = targetUser.Id,
            Tipo = NotificationType.seguidor,
            Mensaje = $"{followerUser.Username} comenzó a seguirte.",
            Leido = false,
            Fecha = DateTime.UtcNow
        });

        return true;
    }
}
