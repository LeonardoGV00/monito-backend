using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MonitoNet.Backend.Iam.Application.CommandServices;
using MonitoNet.Backend.Iam.Application.QueryServices;
using MonitoNet.Backend.Iam.Domain.Model.Commands;

namespace MonitoNet.Backend.Iam.Interfaces.Rest;

[ApiController]
[Route("api/v1/auth")]
public sealed class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationCommandService _auth;
    private readonly IUserQueryService _users;

    public AuthenticationController(IAuthenticationCommandService auth, IUserQueryService users)
    {
        _auth = auth;
        _users = users;
    }

    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp([FromBody] SignUpCommand command)
    {
        var byUsername = await _users.GetByUsernameAsync(command.Username.Trim());
        if (byUsername is not null) return Conflict(new { message = "Username already exists." });

        var byEmail = await _users.GetByEmailAsync(command.Email.Trim());
        if (byEmail is not null) return Conflict(new { message = "Email already exists." });

        try
        {
            var user = await _auth.SignUpAsync(command);
            return Created($"/api/v1/users/{user.Id}", user);
        }
        catch (MongoWriteException ex) when (ex.WriteError?.Code == 121)
        {
            return BadRequest(new { message = "User does not satisfy database validation.", detail = ex.WriteError?.Message });
        }
    }

    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn([FromBody] SignInCommand command)
    {
        var user = await _auth.SignInAsync(command);
        return user is null ? Unauthorized(new { message = "Invalid credentials." }) : Ok(new { message = "Sign in successful.", user });
    }

    [HttpPost("sign-out")]
    public async Task<IActionResult> SignOut()
    {
        return Ok(new { message = await _auth.SignOutAsync() });
    }
}
