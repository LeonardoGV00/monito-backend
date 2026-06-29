using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
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
    private readonly IProductQueryService _products;

    public PublicationsController(
        IPublicationQueryService publications,
        IPublicationCommandService commands,
        IUserQueryService users,
        IProductQueryService products)
    {
        _publications = publications;
        _commands = commands;
        _users = users;
        _products = products;
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

        if (string.IsNullOrWhiteSpace(command.ProductoRelacionadoId))
        {
            return BadRequest(new { message = "ProductoRelacionadoId is required." });
        }

        var product = await _products.GetByIdAsync(command.ProductoRelacionadoId);
        if (product is null) return NotFound(new { message = "Related product not found." });

        try
        {
            var publication = await _commands.CreateAsync(command);
            return CreatedAtAction(nameof(GetById), new { id = publication.Id }, publication);
        }
        catch (MongoDB.Driver.MongoWriteException ex) when (ex.WriteError?.Code == 121)
        {
            return BadRequest(new { message = "Publication does not satisfy database validation.", detail = ex.WriteError?.Message });
        }
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
