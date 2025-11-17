using System;
using BusTrack_center_API.Notifications.Domain.Model.Commands;
namespace BusTrack_center_API.Notifications.Domain.Model.Aggregates;

/// <summary>
/// Represents a notification generated for a user.
/// </summary>
/// <remarks>
/// This aggregate is used to inform users about events related to bus routes,
/// such as delays or other operational updates. It stores metadata such as
/// creation time, delay minutes and read status.
/// </remarks>
public class Notification
{
    public int Id { get; private set; }
    public int UserId { get; private set; }
    public int? RouteId { get; private set; }
    public string Type { get; private set; }
    public string Message { get; private set; } = string.Empty;
    public int? DelayMinutes { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public bool IsRead { get; private set; }

    
    private Notification() { }

    
    /// <summary>
    /// Creates a new <see cref="Notification"/> instance with explicit values.
    /// </summary>
    /// <param name="userId">Identifier of the user that will receive the notification.</param>
    /// <param name="routeId">Identifier of the related route, or <c>null</c> if not applicable.</param>
    /// <param name="type">Type of notification.</param>
    /// <param name="message">Message to be displayed to the user.</param>
    /// <param name="delayMinutes">
    /// Delay in minutes associated with the notification, or <c>null</c> if there is no delay.
    /// </param>
    public Notification(int userId, int? routeId, string type,
        string message, int? delayMinutes)
    {
        UserId = userId;
        RouteId = routeId;
        Type = type;
        Message = message;
        DelayMinutes = delayMinutes;
        CreatedAt = DateTime.UtcNow;
        IsRead = false;
    }

    
    /// <summary>
    /// Creates a new <see cref="Notification"/> instance from a
    /// <see cref="CreateNotificationCommand"/> object.
    /// </summary>
    /// <param name="command">Command containing the data required to create the notification.</param>
    public Notification(CreateNotificationCommand command)
        : this(command.UserId, command.RouteId, command.Type,
            command.Message, command.DelayMinutes)
    {
    }

    /// <summary>
    /// Marks the notification as read.
    /// </summary>
    public void MarkAsRead()
    {
        IsRead = true;
    }
}