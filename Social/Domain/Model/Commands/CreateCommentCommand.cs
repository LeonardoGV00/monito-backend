using System.ComponentModel.DataAnnotations;

namespace MonitoNet.Backend.Social.Domain.Model.Commands;

public sealed record CreateCommentCommand(
    [property: Required]
    string UserId,

    [property: Required]
    [property: MinLength(1)]
    string Comentario
);
