using BusTrack_center_API.Notifications.Domain.Model.Aggregates;
using BusTrack_center_API.Shared.Domain.Repositories;
namespace BusTrack_center_API.Notifications.Domain.Repositories;

/// <summary>
/// Defines the contract for managing <see cref="Notification"/> aggregates in the persistence layer.
/// </summary>
/// <remarks>
/// This repository extends the generic <see cref="IBaseRepository{T}"/> to include
/// notification-specific queries required by the Notifications bounded context.
/// </remarks>
public interface INotificationRepository : IBaseRepository<Notification>
{
    /// <summary>
    /// Retrieves all notifications associated with a given user.
    /// </summary>
    /// <param name="userId">
    /// The identifier of the user whose notifications are being requested.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a collection of <see cref="Notification"/> instances
    /// that belong to the specified user.
    /// </returns>
    Task<IEnumerable<Notification>> ListByUserIdAsync(int userId);
}