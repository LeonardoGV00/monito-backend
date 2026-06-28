using MongoDB.Driver;
using MonitoNet.Backend.Iam.Domain.Model.Aggregates;
using MonitoNet.Backend.Iam.Domain.Repositories;

namespace MonitoNet.Backend.Infrastructure.Persistence.Mongo.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly IMongoCollection<User> _collection;

    public UserRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<User>("usuarios");
    }

    public Task<List<User>> GetAllAsync() => _collection.Find(Builders<User>.Filter.Empty).ToListAsync();
    public Task<User?> GetByIdAsync(string id) => _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
    public Task<User?> GetByEmailAsync(string email) => _collection.Find(x => x.Email == email).FirstOrDefaultAsync();
    public Task<User?> GetByUsernameAsync(string username) => _collection.Find(x => x.Username == username).FirstOrDefaultAsync();
    public Task<User?> GetByLoginAsync(string login)
    {
        var filter = Builders<User>.Filter.Or(
            Builders<User>.Filter.Eq(x => x.Username, login),
            Builders<User>.Filter.Eq(x => x.Email, login));
        return _collection.Find(filter).FirstOrDefaultAsync();
    }
    public Task CreateAsync(User user) => _collection.InsertOneAsync(user);
    public async Task<bool> IncrementFollowersAsync(string userId)
    {
        var result = await _collection.UpdateOneAsync(x => x.Id == userId, Builders<User>.Update.Inc(x => x.Followers, 1));
        return result.ModifiedCount > 0;
    }
}
