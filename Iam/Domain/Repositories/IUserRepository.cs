using MonitoNet.Backend.Iam.Domain.Model.Aggregates;

namespace MonitoNet.Backend.Iam.Domain.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetByIdAsync(string id);
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByUsernameAsync(string username);
    Task<User?> GetByLoginAsync(string login);
    Task CreateAsync(User user);
    Task<bool> IncrementFollowersAsync(string userId);
}
