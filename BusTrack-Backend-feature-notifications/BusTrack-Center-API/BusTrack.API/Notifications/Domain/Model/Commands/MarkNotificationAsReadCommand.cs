namespace BusTrack_center_API.Notifications.Domain.Model.Commands;

/// <summary>
/// Command used to mark an existing notification as read.
/// </summary>
/// <remarks>
/// This command only carries the identifier of the notification
/// that should be updated. It is typically handled by a command
/// service within the Notifications bounded context.
/// </remarks>
public class MarkNotificationAsReadCommand
{
    public int NotificationId { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MarkNotificationAsReadCommand"/> class.
    /// </summary>
    /// <param name="notificationId">
    /// Identifier of the notification that should be updated.
    /// </param>
    public MarkNotificationAsReadCommand(int notificationId)
    {
        NotificationId = notificationId;
    }
}