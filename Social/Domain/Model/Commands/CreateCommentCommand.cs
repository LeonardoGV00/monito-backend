namespace MonitoNet.Backend.Social.Domain.Model.Commands;

public sealed record CreateCommentCommand(
    string UserId,
    string Comentario
);
