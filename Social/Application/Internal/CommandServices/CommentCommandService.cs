using MonitoNet.Backend.Iam.Application.QueryServices;
using MonitoNet.Backend.Social.Application.CommandServices;
using MonitoNet.Backend.Social.Domain.Model.Commands;
using MonitoNet.Backend.Social.Domain.Model.Enums;
using MonitoNet.Backend.Social.Domain.Model.Entities;
using MonitoNet.Backend.Social.Domain.Repositories;

namespace MonitoNet.Backend.Social.Application.Internal.CommandServices;

public sealed class CommentCommandService : ICommentCommandService
{
    private readonly IPublicationRepository _publications;
    private readonly IUserQueryService _users;
    private readonly INotificationCommandService _notifications;

    public CommentCommandService(
        IPublicationRepository publications,
        IUserQueryService users,
        INotificationCommandService notifications)
    {
        _publications = publications;
        _users = users;
        _notifications = notifications;
    }

    public async Task<PublicationComment?> AddAsync(string publicationId, CreateCommentCommand command)
    {
        var publication = await _publications.GetByIdAsync(publicationId);
        var user = await _users.GetByIdAsync(command.UserId);
        if (publication is null || user is null) return null;

        var comment = new PublicationComment
        {
            UsuarioId = command.UserId,
            Comentario = command.Comentario,
            Fecha = DateTime.UtcNow,
            Respuestas = []
        };

        var updated = await _publications.AddCommentAsync(publicationId, comment);
        if (!updated) return null;

        var author = await _users.GetByIdAsync(publication.AutorId);
        if (author is not null && author.Id != user.Id)
        {
            await _notifications.CreateAsync(new MonitoNet.Backend.Social.Domain.Model.Aggregates.Notification
            {
                UsuarioId = author.Id,
                Tipo = NotificationType.comentario,
                Mensaje = $"{user.Username} comentó tu publicación.",
                Leido = false,
                Fecha = DateTime.UtcNow
            });
        }

        return comment;
    }

    public Task<bool> DeleteAsync(string publicationId, string commentId) => _publications.DeleteCommentAsync(publicationId, commentId);
}
