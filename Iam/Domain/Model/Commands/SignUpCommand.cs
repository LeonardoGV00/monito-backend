using System.ComponentModel.DataAnnotations;

namespace MonitoNet.Backend.Iam.Domain.Model.Commands;

public sealed class SignUpCommand
{
    [Required]
    [MinLength(3)]
    public string Username { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MinLength(6)]
    public string Password { get; set; } = string.Empty;

    public string? Rol { get; set; }
    public string? Telefono { get; set; }
    public string? Picture { get; set; }
}
