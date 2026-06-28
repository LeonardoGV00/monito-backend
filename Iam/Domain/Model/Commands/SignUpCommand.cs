namespace MonitoNet.Backend.Iam.Domain.Model.Commands;

public sealed record SignUpCommand(
    string Username,
    string Email,
    string Password,
    string Rol,
    string Telefono,
    string Picture
);
