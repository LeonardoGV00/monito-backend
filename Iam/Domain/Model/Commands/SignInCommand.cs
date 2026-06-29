using System.ComponentModel.DataAnnotations;

namespace MonitoNet.Backend.Iam.Domain.Model.Commands;

public sealed record SignInCommand(
    [property: Required]
    string Login,

    [property: Required]
    string Password
);
