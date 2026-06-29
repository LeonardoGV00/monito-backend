using MongoDB.Driver;
using MonitoNet.Backend.Social.Domain.Model.Aggregates;
using MonitoNet.Backend.Social.Domain.Model.Entities;
using MonitoNet.Backend.Social.Domain.Repositories;

namespace MonitoNet.Backend.Infrastructure.Persistence.Mongo.Repositories;

public sealed class PublicationRepository : IPublicationRepository
{
    private readonly IMongoCollection<Publication> _collection;

    public PublicationRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<Publication>("publicaciones");
    }

    public Task<List<Publication>> GetAllAsync() =>
        _collection.Find(Builders<Publication>.Filter.Empty).ToListAsync();

    public Task<Publication?> GetByIdAsync(string id) =>
        _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public Task CreateAsync(Publication publication) =>
        _collection.InsertOneAsync(publication);

    public async Task<bool> UpdateAsync(Publication publication) =>
        (await _collection.ReplaceOneAsync(x => x.Id == publication.Id, publication)).ModifiedCount > 0;

    public async Task<bool> DeleteAsync(string id) =>
        (await _collection.DeleteOneAsync(x => x.Id == id)).DeletedCount > 0;

    public async Task<bool> IncrementLikesAsync(string publicationId) =>
        (await _collection.UpdateOneAsync(x => x.Id == publicationId,
            Builders<Publication>.Update.Inc(x => x.Likes, 1))).ModifiedCount > 0;

    public async Task<bool> AddCommentAsync(string publicationId, PublicationComment comment) =>
        (await _collection.UpdateOneAsync(x => x.Id == publicationId,
            Builders<Publication>.Update.Push(x => x.Comentarios, comment))).ModifiedCount > 0;

    public async Task<bool> DeleteCommentAsync(string publicationId, string commentId) =>
        (await _collection.UpdateOneAsync(x => x.Id == publicationId,
            Builders<Publication>.Update.PullFilter(x => x.Comentarios, c => c.Id == commentId))).ModifiedCount > 0;
}
