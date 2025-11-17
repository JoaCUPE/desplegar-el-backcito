namespace BusTrack_center_API.Notifications.Interfaces.REST.Resources;


/// <summary>
/// Resource used to expose notification information through the REST API.
/// </summary>
/// <remarks>
/// This resource is returned to the client when listing or retrieving
/// notifications for a user. It represents a projection of the
/// <see cref="Notifications.Domain.Model.Aggregates.Notification"/> domain entity.
/// </remarks>
public class NotificationResource
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int? RouteId { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public int? DelayMinutes { get; set; }
    public bool IsRead { get; set; }
    public DateTime CreatedAt { get; set; }
}