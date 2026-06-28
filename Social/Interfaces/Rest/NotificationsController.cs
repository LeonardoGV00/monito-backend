using Microsoft.AspNetCore.Mvc;
using MonitoNet.Backend.Social.Application.QueryServices;

namespace MonitoNet.Backend.Social.Interfaces.Rest;

[ApiController]
[Route("api/v1/notifications")]
public sealed class NotificationsController : ControllerBase
{
    private readonly INotificationQueryService _notifications;

    public NotificationsController(INotificationQueryService notifications)
    {
        _notifications = notifications;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _notifications.GetAllAsync());

    [HttpGet("/api/v1/users/{userId}/notifications")]
    public async Task<IActionResult> GetByUserId(string userId) => Ok(await _notifications.GetByUserIdAsync(userId));
}
