using System.ComponentModel.DataAnnotations;

namespace MonitoNet.Backend.Social.Domain.Model.Commands;

public sealed class CreateCommentCommand
{
    [Required]
    public string UserId { get; set; } = string.Empty;

    [Required]
    [MinLength(1)]
    public string Comentario { get; set; } = string.Empty;
}
