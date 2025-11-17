using BusTrack_center_API.Notifications.Domain.Model.Aggregates;
using BusTrack_center_API.Notifications.Domain.Model.Queries;
namespace BusTrack_center_API.Notifications.Domain.Services;

/// <summary>
/// Defines the contract for handling notification-related queries
/// in the Notifications bounded context.
/// </summary>
/// <remarks>
/// This query service is responsible for retrieving notification data,
/// keeping read operations separated from write operations following
/// the CQRS (Command Query Responsibility Segregation) pattern.
/// </remarks>
public interface INotificationQueryService
{
    
    /// <summary>
    /// Retrieves all notifications associated with a specific user.
    /// </summary>
    /// <param name="query">
    /// The query object that contains the user identifier used to filter notifications.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a collection of <see cref="Notification"/> instances
    /// that belong to the user specified in the query.
    /// </returns>
    Task<IEnumerable<Notification>> Handle(GetNotificationsByUserQuery query);
}