using MonitoNet.Backend.Social.Domain.Model.Aggregates;

namespace MonitoNet.Backend.Social.Application.QueryServices;

public interface IProductQueryService
{
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(string id);
}
