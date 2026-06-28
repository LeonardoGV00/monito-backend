using Microsoft.AspNetCore.Mvc;
using MonitoNet.Backend.Iam.Application.CommandServices;
using MonitoNet.Backend.Iam.Application.QueryServices;
using MonitoNet.Backend.Iam.Domain.Model.Commands;

namespace MonitoNet.Backend.Iam.Interfaces.Rest;

[ApiController]
[Route("api/v1/users")]
public sealed class UsersController : ControllerBase
{
    private readonly IUserQueryService _users;
    private readonly IUserCommandService _commands;

    public UsersController(IUserQueryService users, IUserCommandService commands)
    {
        _users = users;
        _commands = commands;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _users.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var user = await _users.GetByIdAsync(id);
        return user is null ? NotFound() : Ok(user);
    }

    [HttpPost("{id}/follow")]
    public async Task<IActionResult> Follow(string id, [FromBody] FollowUserCommand command)
    {
        var updated = await _commands.FollowAsync(id, command);
        return updated ? Ok(new { message = "Follower added." }) : NotFound(new { message = "User not found." });
    }
}
