using MonitoNet.Backend.Iam.Application.QueryServices;
using MonitoNet.Backend.Social.Application.CommandServices;
using MonitoNet.Backend.Social.Domain.Model.Aggregates;
using MonitoNet.Backend.Social.Domain.Model.Enums;
using MonitoNet.Backend.Social.Domain.Model.Commands;
using MonitoNet.Backend.Social.Domain.Model.Entities;
using MonitoNet.Backend.Social.Domain.Repositories;

namespace MonitoNet.Backend.Social.Application.Internal.CommandServices;

public sealed class PublicationCommandService : IPublicationCommandService
{
    private readonly IPublicationRepository _publications;
    private readonly IUserQueryService _users;
    private readonly INotificationCommandService _notifications;

    public PublicationCommandService(
        IPublicationRepository publications,
        IUserQueryService users,
        INotificationCommandService notifications)
    {
        _publications = publications;
        _users = users;
        _notifications = notifications;
    }

    public async Task<Publication> CreateAsync(CreatePublicationCommand command)
    {
        var publication = new Publication
        {
            AutorId = command.AutorId,
            ProductoRelacionadoId = command.ProductoRelacionadoId,
            Titulo = command.Titulo,
            Descripcion = command.Descripcion,
            Multimedia = command.Multimedia.Select(x => new PublicationMedia
            {
                Tipo = x.Tipo,
                Url = x.Url,
                Formato = x.Formato
            }).ToList(),
            Likes = 0,
            Comentarios = [],
            FechaPublicacion = DateTime.UtcNow
        };

        await _publications.CreateAsync(publication);
        return publication;
    }

    public async Task<bool> LikeAsync(string publicationId, LikePublicationCommand command)
    {
        var publication = await _publications.GetByIdAsync(publicationId);
        var user = await _users.GetByIdAsync(command.UserId);
        if (publication is null || user is null) return false;

        var updated = await _publications.IncrementLikesAsync(publicationId);
        if (!updated) return false;

        var author = await _users.GetByIdAsync(publication.AutorId);
        if (author is not null && author.Id != user.Id)
        {
            await _notifications.CreateAsync(new Notification
            {
                UsuarioId = author.Id,
                Tipo = NotificationType.Like,
                Mensaje = $"{user.Username} dio like a tu publicación.",
                Leido = false,
                Fecha = DateTime.UtcNow
            });
        }

        return true;
    }

    public Task<bool> DeleteAsync(string publicationId) => _publications.DeleteAsync(publicationId);
}
