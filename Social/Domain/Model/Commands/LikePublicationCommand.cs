using System.ComponentModel.DataAnnotations;

namespace MonitoNet.Backend.Social.Domain.Model.Commands;

public sealed record LikePublicationCommand(
    [property: Required]
    string UserId
);
