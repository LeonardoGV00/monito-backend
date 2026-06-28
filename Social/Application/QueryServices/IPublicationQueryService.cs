using MonitoNet.Backend.Social.Domain.Model.Aggregates;

namespace MonitoNet.Backend.Social.Application.QueryServices;

public interface IPublicationQueryService
{
    Task<List<Publication>> GetAllAsync();
    Task<Publication?> GetByIdAsync(string id);
}
