using BusTrack_center_API.Notifications.Domain.Model.Aggregates;
using BusTrack_center_API.Notifications.Domain.Repositories;
using BusTrack_center_API.Shared.Infrastructure.Persistence.EFC;
using BusTrack_center_API.Shared.Infrastructure.Persistence.EFC.Repositories; // BaseRepository
using Microsoft.EntityFrameworkCore;
namespace BusTrack_center_API.Notifications.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Repository implementation for <see cref="Notification"/> entities.
/// </summary>
/// <remarks>
/// This class provides persistence operations for the Notifications bounded context,
/// extending the generic <see cref="BaseRepository{T}"/> and adding query methods
/// specific to the <see cref="Notification"/> aggregate.
/// </remarks>
public class NotificationRepository 
    : BaseRepository<Notification>, INotificationRepository
{
    
    /// <summary>
    /// Initializes a new instance of the <see cref="NotificationRepository"/> class.
    /// </summary>
    /// <param name="context">
    /// The <see cref="AppDbContext"/> used to access the database.
    /// </param>
    public NotificationRepository(AppDbContext context) : base(context)
    {
    }

    
    /// <summary>
    /// Retrieves all notifications that belong to a specific user.
    /// </summary>
    /// <param name="userId">
    /// The identifier of the user whose notifications will be retrieved.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a collection of <see cref="Notification"/> objects
    /// ordered by <see cref="Notification.CreatedAt"/> in descending order
    /// (most recent notif
    public async Task<IEnumerable<Notification>> ListByUserIdAsync(int userId)
    {
        return await Context.Set<Notification>()
            .Where(n => n.UserId == userId)
            .OrderByDescending(n => n.CreatedAt)
            .ToListAsync();
    }
}