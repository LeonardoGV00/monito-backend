using MonitoNet.Backend.Social.Application.QueryServices;
using MonitoNet.Backend.Social.Domain.Model.Aggregates;
using MonitoNet.Backend.Social.Domain.Repositories;

namespace MonitoNet.Backend.Social.Application.Internal.QueryServices;

public sealed class PublicationQueryService : IPublicationQueryService
{
    private readonly IPublicationRepository _publications;

    public PublicationQueryService(IPublicationRepository publications)
    {
        _publications = publications;
    }

    public Task<List<Publication>> GetAllAsync() => _publications.GetAllAsync();
    public Task<Publication?> GetByIdAsync(string id) => _publications.GetByIdAsync(id);
}
