using BusTrack_center_API.Notifications.Domain.Model.Aggregates;
using BusTrack_center_API.Notifications.Interfaces.REST.Resources;
namespace BusTrack_center_API.Notifications.Interfaces.REST.Transform;

/// <summary>
/// Provides mapping utilities to convert notification domain entities
/// into REST-facing resources.
/// </summary>
/// <remarks>
/// This assembler isolates the transformation logic from the domain model
/// (<see cref="Notification"/>) to the API contract
/// (<see cref="NotificationResource"/>), helping to keep controllers slim
/// and the domain model independent from transport concerns.
/// </remarks>
public static class NotificationResourceFromEntityAssembler
{
    /// <summary>
    /// Maps a <see cref="Notification"/> entity to a
    /// <see cref="NotificationResource"/> used by the REST API.
    /// </summary>
    /// <param name="entity">
    /// The notification domain entity to be converted.
    /// </param>
    /// <returns>
    /// A <see cref="NotificationResource"/> instance containing the
    /// serialized data that will be returned to API clients.
    /// </returns>
    public static NotificationResource ToResource(Notification entity)
    {
        return new NotificationResource
        {
            Id = entity.Id,
            UserId = entity.UserId,
            RouteId = entity.RouteId,
            Type = entity.Type,
            Message = entity.Message,
            DelayMinutes = entity.DelayMinutes,
            IsRead = entity.IsRead,
            CreatedAt = entity.CreatedAt
        };
    }
}
