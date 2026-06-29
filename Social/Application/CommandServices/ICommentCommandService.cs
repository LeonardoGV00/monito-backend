using MonitoNet.Backend.Social.Domain.Model.Entities;
using MonitoNet.Backend.Social.Domain.Model.Commands;

namespace MonitoNet.Backend.Social.Application.CommandServices;

public interface ICommentCommandService
{
    Task<PublicationComment?> AddAsync(string publicationId, CreateCommentCommand command);
    Task<PublicationComment?> UpdateAsync(string publicationId, string commentId, UpdateCommentCommand command);
    Task<bool> DeleteAsync(string publicationId, string commentId);
}
