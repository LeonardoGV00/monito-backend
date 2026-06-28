using MongoDB.Driver;
using MonitoNet.Backend.Social.Domain.Model.Aggregates;
using MonitoNet.Backend.Social.Domain.Repositories;

namespace MonitoNet.Backend.Infrastructure.Persistence.Mongo.Repositories;

public sealed class NotificationRepository : INotificationRepository
{
    private readonly IMongoCollection<Notification> _collection;

    public NotificationRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<Notification>("notificaciones");
    }

    public Task<List<Notification>> GetAllAsync() => _collection.Find(Builders<Notification>.Filter.Empty).ToListAsync();
    public Task<List<Notification>> GetByUserIdAsync(string userId) => _collection.Find(x => x.UsuarioId == userId).SortByDescending(x => x.Fecha).ToListAsync();
    public Task CreateAsync(Notification notification) => _collection.InsertOneAsync(notification);
}
