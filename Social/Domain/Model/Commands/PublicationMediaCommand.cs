using System.ComponentModel.DataAnnotations;

namespace MonitoNet.Backend.Social.Domain.Model.Commands;

public sealed record PublicationMediaCommand(
    [property: Required]
    string Tipo,

    [property: Required]
    string Url,

    [property: Required]
    string Formato
);
