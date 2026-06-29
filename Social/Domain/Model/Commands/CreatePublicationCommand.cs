using System.ComponentModel.DataAnnotations;

namespace MonitoNet.Backend.Social.Domain.Model.Commands;

public sealed record CreatePublicationCommand(
    [property: Required]
    string AutorId,

    string? ProductoRelacionadoId,

    [property: Required]
    [property: MinLength(1)]
    string Titulo,

    [property: Required]
    [property: MinLength(1)]
    string Descripcion,

    List<PublicationMediaCommand>? Multimedia = null
);
