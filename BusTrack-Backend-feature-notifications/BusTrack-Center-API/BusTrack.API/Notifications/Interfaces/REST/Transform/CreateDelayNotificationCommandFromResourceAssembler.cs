using BusTrack_center_API.Notifications.Domain.Model.Commands;
using BusTrack_center_API.Notifications.Interfaces.REST.Resources;
namespace BusTrack_center_API.Notifications.Interfaces.REST.Transform;

/// <summary>
/// Provides transformation logic from REST resources to notification commands.
/// </summary>
/// <remarks>
/// This assembler converts an incoming <see cref="CreateDelayNotificationResource"/>
/// (used by the API layer) into a <see cref="CreateNotificationCommand"/> 
/// that can be processed by the application layer.
/// </remarks>
public static class CreateDelayNotificationCommandFromResourceAssembler
{
    
    /// <summary>
    /// Maps a <see cref="CreateDelayNotificationResource"/> to a
    /// <see cref="CreateNotificationCommand"/> for delay notifications.
    /// </summary>
    /// <param name="resource">
    /// The REST resource containing delay notification data sent by the client.
    /// </param>
    /// <returns>
    /// A <see cref="CreateNotificationCommand"/> instance populated with the
    /// corresponding values from the provided resource.
    /// </returns>
    /// <remarks>
    /// The notification type is set explicitly to <c>"Delay"</c>, as this assembler
    /// is intended only for delay-related notifications.
    /// </remarks>
    public static CreateNotificationCommand ToCommand(CreateDelayNotificationResource resource)
    {
        
        return new CreateNotificationCommand(
            resource.UserId,
            resource.RouteId,
            "Delay",
            resource.Message,
            resource.DelayMinutes
        );
    }
}