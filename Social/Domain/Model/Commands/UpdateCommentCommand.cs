namespace MonitoNet.Backend.Social.Domain.Model.Commands;

public sealed record UpdateCommentCommand(
    string UserId,
    string Comentario
);
