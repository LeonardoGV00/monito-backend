using Microsoft.AspNetCore.Mvc;
using MonitoNet.Backend.Iam.Application.QueryServices;
using MonitoNet.Backend.Social.Application.CommandServices;
using MonitoNet.Backend.Social.Application.QueryServices;
using MonitoNet.Backend.Social.Domain.Model.Commands;

namespace MonitoNet.Backend.Social.Interfaces.Rest;

[ApiController]
[Route("api/v1/publications")]
public sealed class PublicationsController : ControllerBase
{
    private readonly IPublicationQueryService _publications;
    private readonly IPublicationCommandService _commands;
    private readonly IUserQueryService _users;

    public PublicationsController(IPublicationQueryService publications, IPublicationCommandService commands, IUserQueryService users)
    {
        _publications = publications;
        _commands = commands;
        _users = users;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _publications.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var publication = await _publications.GetByIdAsync(id);
        return publication is null ? NotFound() : Ok(publication);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePublicationCommand command)
    {
        var author = await _users.GetByIdAsync(command.AutorId);
        if (author is null) return NotFound(new { message = "Author not found." });

        var publication = await _commands.CreateAsync(command);
        return CreatedAtAction(nameof(GetById), new { id = publication.Id }, publication);
    }

    [HttpPost("{id}/like")]
    public async Task<IActionResult> Like(string id, [FromBody] LikePublicationCommand command)
    {
        var updated = await _commands.LikeAsync(id, command);
        return updated ? Ok(new { message = "Like added." }) : NotFound(new { message = "Publication or user not found." });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var deleted = await _commands.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
