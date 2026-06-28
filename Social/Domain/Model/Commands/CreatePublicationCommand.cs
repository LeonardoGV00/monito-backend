namespace MonitoNet.Backend.Social.Domain.Model.Commands;

public sealed record CreatePublicationCommand(
    string AutorId,
    string? ProductoRelacionadoId,
    string Titulo,
    string Descripcion,
    List<PublicationMediaCommand> Multimedia
);
