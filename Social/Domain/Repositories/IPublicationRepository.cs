using MonitoNet.Backend.Social.Domain.Model.Aggregates;
using MonitoNet.Backend.Social.Domain.Model.Entities;

namespace MonitoNet.Backend.Social.Domain.Repositories;

public interface IPublicationRepository
{
    Task<List<Publication>> GetAllAsync();
    Task<Publication?> GetByIdAsync(string id);
    Task CreateAsync(Publication publication);
    Task<bool> DeleteAsync(string id);
    Task<bool> IncrementLikesAsync(string publicationId);
    Task<bool> AddCommentAsync(string publicationId, PublicationComment comment);
    Task<bool> DeleteCommentAsync(string publicationId, string commentId);
}
