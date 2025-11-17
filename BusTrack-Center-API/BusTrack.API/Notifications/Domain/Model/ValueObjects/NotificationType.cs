namespace BusTrack_center_API.Notifications.Domain.Model.ValueObjects;

/// <summary>
/// Represents the type of notification that can be sent to a user.
/// </summary>
/// <remarks>
/// This value object is used to classify notifications according to
/// their purpose or context within the BusTrack application.
/// </remarks>
public enum NotificationType
{
    Delay,
    Diversion
}
