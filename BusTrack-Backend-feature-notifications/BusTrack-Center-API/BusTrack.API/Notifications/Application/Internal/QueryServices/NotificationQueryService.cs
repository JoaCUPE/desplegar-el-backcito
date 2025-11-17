using BusTrack_center_API.Notifications.Domain.Model.Aggregates;
using BusTrack_center_API.Notifications.Domain.Model.Queries;
using BusTrack_center_API.Notifications.Domain.Repositories;
using BusTrack_center_API.Notifications.Domain.Services;
namespace BusTrack_center_API.Notifications.Application.Internal.QueryServices;

/// <summary>
/// Application service responsible for handling read-only queries
/// related to notifications.
/// </summary>
/// <remarks>
/// This service delegates data access to <see cref="INotificationRepository"/>
/// and exposes high-level query methods used by the API layer.
/// </remarks>
public class NotificationQueryService : INotificationQueryService
{
    private readonly INotificationRepository _notificationRepository;

    /// <summary>
    /// Creates a new instance of <see cref="NotificationQueryService"/>.
    /// </summary>
    /// <param name="notificationRepository">
    /// Repository that provides read operations for notifications.
    /// </param>
    public NotificationQueryService(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    /// <summary>
    /// Handles a query to retrieve all notifications that belong to a given user.
    /// </summary>
    /// <param name="query">
    /// Query object that contains the <see cref="GetNotificationsByUserQuery.UserId"/> to filter by.
    /// </param>
    /// <returns>
    /// A collection of <see cref="Notification"/> entities associated with the requested user.
    /// </returns>
    public async Task<IEnumerable<Notification>> Handle(GetNotificationsByUserQuery query)
    {
        return await _notificationRepository.ListByUserIdAsync(query.UserId);
    }
}