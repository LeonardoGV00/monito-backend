namespace MonitoNet.Backend.Iam.Domain.Model.Commands;

public sealed record SignInCommand(
    string Login,
    string Password
);
