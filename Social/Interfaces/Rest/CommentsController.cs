using Microsoft.AspNetCore.Mvc;
using MonitoNet.Backend.Social.Application.CommandServices;
using MonitoNet.Backend.Social.Domain.Model.Commands;

namespace MonitoNet.Backend.Social.Interfaces.Rest;

[ApiController]
[Route("api/v1/publications/{publicationId}/comments")]
public sealed class CommentsController : ControllerBase
{
    private readonly ICommentCommandService _comments;

    public CommentsController(ICommentCommandService comments)
    {
        _comments = comments;
    }

    [HttpPost]
    public async Task<IActionResult> Add(string publicationId, [FromBody] CreateCommentCommand command)
    {
        var comment = await _comments.AddAsync(publicationId, command);
        return comment is null
            ? NotFound(new { message = "Publication or user not found." })
            : Ok(new { message = "Comment added.", commentId = comment.Id });
    }

    [HttpPut("{commentId}")]
    public async Task<IActionResult> Update(string publicationId, string commentId, [FromBody] UpdateCommentCommand command)
    {
        var comment = await _comments.UpdateAsync(publicationId, commentId, command);
        return comment is null
            ? NotFound(new { message = "Publication, user or comment not found." })
            : Ok(new { message = "Comment updated.", comment });
    }

    [HttpDelete("{commentId}")]
    public async Task<IActionResult> Delete(string publicationId, string commentId)
    {
        var deleted = await _comments.DeleteAsync(publicationId, commentId);
        return deleted ? NoContent() : NotFound();
    }
}
