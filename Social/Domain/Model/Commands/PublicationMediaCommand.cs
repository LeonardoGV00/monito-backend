namespace MonitoNet.Backend.Social.Domain.Model.Commands;

public sealed record PublicationMediaCommand(
    string Tipo,
    string Url,
    string Formato
);
