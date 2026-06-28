using MonitoNet.Backend.Iam.Domain.Model.Aggregates;

namespace MonitoNet.Backend.Iam.Application.QueryServices;

public interface IUserQueryService
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetByIdAsync(string id);
    Task<User?> GetByLoginAsync(string login);
    Task<User?> GetByUsernameAsync(string username);
    Task<User?> GetByEmailAsync(string email);
}
