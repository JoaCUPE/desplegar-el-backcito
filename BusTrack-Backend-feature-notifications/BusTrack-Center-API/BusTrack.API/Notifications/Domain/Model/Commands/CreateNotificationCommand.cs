namespace BusTrack_center_API.Notifications.Domain.Model.Commands;

/// <summary>
/// Command used to request the creation of a new notification.
/// </summary>
/// <remarks>
/// This command encapsulates all the data required by the domain
/// to create a <c>Notification</c> instance, typically handled
/// by a command service in the Notifications bounded context.
/// </remarks>
public class CreateNotificationCommand
{
    public int UserId { get; }
    public int? RouteId { get; }
    public string Type { get; }
    public string Message { get; }
    public int? DelayMinutes { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateNotificationCommand"/> class.
    /// </summary>
    /// <param name="userId">Identifier of the target user.</param>
    /// <param name="routeId">Identifier of the related route, or <c>null</c>.</param>
    /// <param name="type">Notification type.</param>
    /// <param name="message">Message content of the notification.</param>
    /// <param name="delayMinutes">Delay in minutes, or <c>null</c> if not applicable.</param>
    public CreateNotificationCommand(
        int userId,
        int? routeId,
        string type,
        string message,
        int? delayMinutes)
    {
        UserId = userId;
        RouteId = routeId;
        Type = type;
        Message = message;
        DelayMinutes = delayMinutes;
    }
}