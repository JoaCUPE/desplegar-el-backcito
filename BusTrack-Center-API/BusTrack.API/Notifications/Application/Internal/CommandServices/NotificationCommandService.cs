using BusTrack_center_API.Notifications.Domain.Model.Aggregates;
using BusTrack_center_API.Notifications.Domain.Model.Commands;
using BusTrack_center_API.Notifications.Domain.Repositories;
using BusTrack_center_API.Notifications.Domain.Services;
using BusTrack_center_API.Shared.Domain.Repositories;
namespace BusTrack_center_API.Notifications.Application.Internal.CommandServices;

/// <summary>
/// Application service responsible for handling commands related to
/// the notification lifecycle.
/// </summary>
/// <remarks>
/// This service coordinates the creation of notifications and the
/// change of their state (for example, marking them as read),
/// delegating data access to <see cref="INotificationRepository"/>
/// and transaction control to <see cref="IUnitOfWork"/>.
/// </remarks>
public class NotificationCommandService : INotificationCommandService
{
    private readonly INotificationRepository _notificationRepository;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Creates a new instance of <see cref="NotificationCommandService"/>.
    /// </summary>
    /// <param name="notificationRepository">
    /// Repository that encapsulates persistence operations for notifications.
    /// </param>
    /// <param name="unitOfWork">
    /// Unit of work used to commit changes to the database as a single transaction.
    /// </param>
    public NotificationCommandService(
        INotificationRepository notificationRepository,
        IUnitOfWork unitOfWork)
    {
        _notificationRepository = notificationRepository;
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Handles the command to create a new notification.
    /// </summary>
    /// <param name="command">
    /// Command containing the data required to build the notification
    /// (user, route, type, message and delay minutes).
    /// </param>
    /// <returns>
    /// The created <see cref="Notification"/> entity after being persisted.
    /// </returns>
    public async Task<Notification> Handle(CreateNotificationCommand command)
    {
        var notification = new Notification(
            command.UserId,
            command.RouteId,
            command.Type,
            command.Message,
            command.DelayMinutes);

        await _notificationRepository.AddAsync(notification);
        await _unitOfWork.CompleteAsync();

        return notification;
    }

    /// <summary>
    /// Handles the command to mark an existing notification as read.
    /// </summary>
    /// <param name="command">
    /// Command that specifies the identifier of the notification
    /// that should be marked as read.
    /// </param>
    /// <remarks>
    /// If the notification does not exist, the method returns without
    /// performing any operation.
    /// </remarks>
    public async Task Handle(MarkNotificationAsReadCommand command)
    {
        var notification = await _notificationRepository.FindByIdAsync(command.NotificationId);
        if (notification == null) return;

        notification.MarkAsRead();
        _notificationRepository.Update(notification);
        await _unitOfWork.CompleteAsync();
    }
}