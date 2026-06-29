using System.ComponentModel.DataAnnotations;

namespace MonitoNet.Backend.Iam.Domain.Model.Commands;

public sealed class FollowUserCommand
{
    [Required]
    public string FollowerUserId { get; set; } = string.Empty;
}
