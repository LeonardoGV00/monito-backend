using MongoDB.Driver;
using MonitoNet.Backend.Social.Domain.Model.Aggregates;
using MonitoNet.Backend.Social.Domain.Repositories;

namespace MonitoNet.Backend.Infrastructure.Persistence.Mongo.Repositories;

public sealed class ProductRepository : IProductRepository
{
    private readonly IMongoCollection<Product> _collection;

    public ProductRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<Product>("productos");
    }

    public Task<List<Product>> GetAllAsync() => _collection.Find(Builders<Product>.Filter.Empty).ToListAsync();
    public Task<Product?> GetByIdAsync(string id) => _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
}
