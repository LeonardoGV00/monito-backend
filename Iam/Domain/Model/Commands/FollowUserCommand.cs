namespace MonitoNet.Backend.Iam.Domain.Model.Commands;

public sealed record FollowUserCommand(
    string FollowerUserId
);
