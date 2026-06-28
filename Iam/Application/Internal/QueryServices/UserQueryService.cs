using MonitoNet.Backend.Iam.Application.QueryServices;
using MonitoNet.Backend.Iam.Domain.Model.Aggregates;
using MonitoNet.Backend.Iam.Domain.Repositories;

namespace MonitoNet.Backend.Iam.Application.Internal.QueryServices;

public sealed class UserQueryService : IUserQueryService
{
    private readonly IUserRepository _users;

    public UserQueryService(IUserRepository users)
    {
        _users = users;
    }

    public Task<List<User>> GetAllAsync() => _users.GetAllAsync();
    public Task<User?> GetByIdAsync(string id) => _users.GetByIdAsync(id);
    public Task<User?> GetByLoginAsync(string login) => _users.GetByLoginAsync(login);
    public Task<User?> GetByUsernameAsync(string username) => _users.GetByUsernameAsync(username);
    public Task<User?> GetByEmailAsync(string email) => _users.GetByEmailAsync(email);
}
