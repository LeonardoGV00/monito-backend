using System.ComponentModel.DataAnnotations;

namespace MonitoNet.Backend.Social.Domain.Model.Commands;

public sealed class LikePublicationCommand
{
    [Required]
    public string UserId { get; set; } = string.Empty;
}
