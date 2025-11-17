namespace BusTrack_center_API.Notifications.Interfaces.REST.Resources;

/// <summary>
/// Resource used to receive the data required to create
/// a delay notification from the API client.
/// </summary>
/// <remarks>
/// This resource represents the payload sent from the frontend
/// when a bus is delayed and a notification must be generated
/// for a specific user and route.
/// </remarks>
public class CreateDelayNotificationResource
{
    public int UserId { get; set; }
    public int? RouteId { get; set; }
    public int DelayMinutes { get; set; }
    public string Message { get; set; } = string.Empty;
}