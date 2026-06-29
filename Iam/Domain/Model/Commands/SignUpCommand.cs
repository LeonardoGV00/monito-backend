using System.ComponentModel.DataAnnotations;

namespace MonitoNet.Backend.Iam.Domain.Model.Commands;

public sealed record SignUpCommand(
    [property: Required]
    [property: MinLength(3)]
    string Username,

    [property: Required]
    [property: EmailAddress]
    string Email,

    [property: Required]
    [property: MinLength(6)]
    string Password,

    // Se acepta por compatibilidad con clientes antiguos, pero el backend lo ignora
    string? Rol = null,

    string? Telefono = null,
    string? Picture = null
);
