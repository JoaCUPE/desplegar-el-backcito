using BusTrack_center_API.Notifications.Domain.Model.Commands;
using BusTrack_center_API.Notifications.Domain.Model.Queries;
using BusTrack_center_API.Notifications.Domain.Services;
using BusTrack_center_API.Notifications.Interfaces.REST.Resources;
using BusTrack_center_API.Notifications.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace BusTrack_center_API.Notifications.Interfaces.REST;

/// <summary>
/// REST controller responsible for managing notification-related endpoints.
/// </summary>
/// <remarks>
/// Exposes operations to:
/// <list type="bullet">
/// <item><description>Retrieve notifications for a given user.</description></item>
/// <item><description>Create delay notifications when a bus is late.</description></item>
/// <item><description>Mark notifications as read.</description></item>
/// </list>
/// This controller orchestrates the application layer by calling
/// <see cref="INotificationCommandService"/> and <see cref="INotificationQueryService"/>.
/// </remarks>
[ApiController]
[Route("api/v1/[controller]")]
public class NotificationsController : ControllerBase
{
    private readonly INotificationCommandService _commandService;
    private readonly INotificationQueryService _queryService;

    
    /// <summary>
    /// Initializes a new instance of the <see cref="NotificationsController"/> class.
    /// </summary>
    /// <param name="commandService">
    /// Application service used to handle commands that modify notification state.
    /// </param>
    /// <param name="queryService">
    /// Application service used to retrieve notification data.
    /// </param>
    public NotificationsController(
        INotificationCommandService commandService,
        INotificationQueryService queryService)
    {
        _commandService = commandService;
        _queryService = queryService;
    }

    
    /// <summary>
    /// Retrieves all notifications associated with a specific user.
    /// </summary>
    /// <param name="userId">
    /// Identifier of the user whose notifications are requested.
    /// </param>
    /// <returns>
    /// A collection of <see cref="NotificationResource"/> wrapped in an <see cref="ActionResult"/>.
    /// Returns <c>400 BadRequest</c> if the user identifier is invalid.
    /// </returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<NotificationResource>>> GetByUser([FromQuery] int userId)
    {
        if (userId <= 0)
            return BadRequest(new { message = "Invalid userId." });

        var query = new GetNotificationsByUserQuery(userId);
        var notifications = await _queryService.Handle(query);

        var resources = notifications
            .Select(NotificationResourceFromEntityAssembler.ToResource);

        return Ok(resources);
    }

    
    /// <summary>
    /// Creates a delay notification for a user when a bus delay exceeds the allowed threshold.
    /// </summary>
    /// <param name="resource">
    /// Resource containing the delay details, such as user, route and delay minutes.
    /// </param>
    /// <returns>
    /// The created <see cref="NotificationResource"/> wrapped in a
    /// <see cref="CreatedAtActionResult"/> when successful.
    /// Returns <c>400 BadRequest</c> if the model is invalid or the delay is less than
    /// or equal to 10 minutes.
    /// </returns>
    [HttpPost("delays")]
    public async Task<ActionResult<NotificationResource>> CreateDelayNotification(
        [FromBody] CreateDelayNotificationResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (resource.DelayMinutes <= 10)
            return BadRequest(new { message = "Delay must be greater than 10 minutes." });

        var command = CreateDelayNotificationCommandFromResourceAssembler.ToCommand(resource);
        var notification = await _commandService.Handle(command);

        var notificationResource = NotificationResourceFromEntityAssembler.ToResource(notification);

        return CreatedAtAction(nameof(GetByUser),
            new { userId = notification.UserId },
            notificationResource);
    }

    
    /// <summary>
    /// Marks a specific notification as read.
    /// </summary>
    /// <param name="id">
    /// Identifier of the notification to be updated.
    /// </param>
    /// <returns>
    /// <c>NoContent</c> when the operation completes.
    /// Returns <c>400 BadRequest</c> if the notification identifier is invalid.
    /// </returns>
    [HttpPut("{id:int}/read")]
    public async Task<IActionResult> MarkAsRead(int id)
    {
        if (id <= 0)
            return BadRequest(new { message = "Invalid notification id." });

        var command = new MarkNotificationAsReadCommand(id);
        await _commandService.Handle(command);

        return NoContent();
    }
}