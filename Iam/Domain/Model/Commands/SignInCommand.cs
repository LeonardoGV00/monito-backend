using System.ComponentModel.DataAnnotations;

namespace MonitoNet.Backend.Iam.Domain.Model.Commands;

public sealed class SignInCommand
{
    [Required]
    public string Login { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}
