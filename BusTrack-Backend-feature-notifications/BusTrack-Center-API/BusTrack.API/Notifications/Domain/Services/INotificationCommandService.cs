using BusTrack_center_API.Notifications.Domain.Model.Aggregates;
using BusTrack_center_API.Notifications.Domain.Model.Commands;
namespace BusTrack_center_API.Notifications.Domain.Services;

/// <summary>
/// Defines the contract for handling notification-related commands
/// in the Notifications bounded context.
/// </summary>
/// <remarks>
/// This command service encapsulates the application logic for
/// creating notifications and updating their state (e.g., marking them as read),
/// keeping the domain logic separate from controllers and infrastructure.
/// </remarks>
public interface INotificationCommandService
{
    
    /// <summary>
    /// Handles the creation of a new notification based on the provided command.
    /// </summary>
    /// <param name="command">
    /// The command containing the data required to create a new <see cref="Notification"/>.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the newly created <see cref="Notification"/> aggregate.
    /// </returns>
    Task<Notification> Handle(CreateNotificationCommand command);
    
    /// <summary>
    /// Handles the action of marking an existing notification as read.
    /// </summary>
    /// <param name="command">
    /// The command that identifies which notification should be marked as read.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// </returns>
    Task Handle(MarkNotificationAsReadCommand command);
}