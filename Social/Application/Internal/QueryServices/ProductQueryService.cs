using MonitoNet.Backend.Social.Application.QueryServices;
using MonitoNet.Backend.Social.Domain.Model.Aggregates;
using MonitoNet.Backend.Social.Domain.Repositories;

namespace MonitoNet.Backend.Social.Application.Internal.QueryServices;

public sealed class ProductQueryService : IProductQueryService
{
    private readonly IProductRepository _products;

    public ProductQueryService(IProductRepository products)
    {
        _products = products;
    }

    public Task<List<Product>> GetAllAsync() => _products.GetAllAsync();
    public Task<Product?> GetByIdAsync(string id) => _products.GetByIdAsync(id);
}
