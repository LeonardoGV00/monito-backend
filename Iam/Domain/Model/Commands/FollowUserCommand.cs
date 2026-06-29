using System.ComponentModel.DataAnnotations;

namespace MonitoNet.Backend.Iam.Domain.Model.Commands;

public sealed record FollowUserCommand(
    [property: Required]
    string FollowerUserId
);
