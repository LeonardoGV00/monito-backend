using MonitoNet.Backend.Iam.Application.CommandServices;
using MonitoNet.Backend.Iam.Domain.Model.Aggregates;
using MonitoNet.Backend.Iam.Domain.Model.Commands;
using MonitoNet.Backend.Iam.Domain.Model.Enums;
using MonitoNet.Backend.Iam.Domain.Repositories;

namespace MonitoNet.Backend.Iam.Application.Internal.CommandServices;

public sealed class AuthenticationCommandService : IAuthenticationCommandService
{
    private readonly IUserRepository _users;

    public AuthenticationCommandService(IUserRepository users)
    {
        _users = users;
    }

    public async Task<User> SignUpAsync(SignUpCommand command)
    {
        var user = new User
        {
            Username = command.Username.Trim(),
            Email = command.Email.Trim(),
            Password = command.Password,
            Rol = UserRole.cliente,
            Telefono = string.IsNullOrWhiteSpace(command.Telefono) ? string.Empty : command.Telefono.Trim(),
            Picture = string.IsNullOrWhiteSpace(command.Picture) ? string.Empty : command.Picture.Trim(),
            Followers = 0,
            FechaRegistro = DateTime.UtcNow
        };

        await _users.CreateAsync(user);
        return user;
    }

    public async Task<User?> SignInAsync(SignInCommand command)
    {
        var user = await _users.GetByLoginAsync(command.Login.Trim());
        return user is not null && user.Password == command.Password ? user : null;
    }

    public Task<string> SignOutAsync() => Task.FromResult("Sign out successful.");
}
