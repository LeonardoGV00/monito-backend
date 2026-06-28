using MonitoNet.Backend.Iam.Application.CommandServices;
using MonitoNet.Backend.Iam.Domain.Model.Aggregates;
using MonitoNet.Backend.Iam.Domain.Model.Commands;
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
            Username = command.Username,
            Email = command.Email,
            Password = command.Password,
            Rol = string.IsNullOrWhiteSpace(command.Rol) ? "cliente" : command.Rol,
            Telefono = command.Telefono,
            Picture = command.Picture,
            Followers = 0,
            FechaRegistro = DateTime.UtcNow
        };

        await _users.CreateAsync(user);
        return user;
    }

    public async Task<User?> SignInAsync(SignInCommand command)
    {
        var user = await _users.GetByLoginAsync(command.Login);
        return user is not null && user.Password == command.Password ? user : null;
    }

    public Task<string> SignOutAsync() => Task.FromResult("Sign out successful.");
}
