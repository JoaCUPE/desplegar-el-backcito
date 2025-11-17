namespace BusTrack_center_API.Notifications.Domain.Model.Queries;

/// <summary>
/// Query used to retrieve all notifications associated with a specific user.
/// </summary>
/// <remarks>
/// This query encapsulates the user identifier required to fetch
/// notifications from the corresponding repository or query service.
/// It follows the CQRS pattern used across the Notifications bounded context.
/// </remarks>
public class GetNotificationsByUserQuery
{
    public int UserId { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GetNotificationsByUserQuery"/> class.
    /// </summary>
    /// <param name="userId">
    /// The identifier of the user whose notifications should be retrieved.
    /// </param>
    public GetNotificationsByUserQuery(int userId)
    {
        UserId = userId;
    }
}