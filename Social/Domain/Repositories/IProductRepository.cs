using MonitoNet.Backend.Social.Domain.Model.Aggregates;

namespace MonitoNet.Backend.Social.Domain.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(string id);
}
