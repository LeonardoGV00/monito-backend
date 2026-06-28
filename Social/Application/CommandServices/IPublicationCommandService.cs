using MonitoNet.Backend.Social.Domain.Model.Aggregates;
using MonitoNet.Backend.Social.Domain.Model.Commands;

namespace MonitoNet.Backend.Social.Application.CommandServices;

public interface IPublicationCommandService
{
    Task<Publication> CreateAsync(CreatePublicationCommand command);
    Task<bool> LikeAsync(string publicationId, LikePublicationCommand command);
    Task<bool> DeleteAsync(string publicationId);
}
