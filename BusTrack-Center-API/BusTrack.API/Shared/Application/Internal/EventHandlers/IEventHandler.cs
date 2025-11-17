using BusTrack_center_API.Shared.Domain.Model.Events;
using Cortex.Mediator.Notifications;

namespace BusTrack_center_API.Shared.Application.Internal.EventHandlers;

public interface IEventHandler<in TEvent> : INotificationHandler<TEvent> where TEvent : IEvent
{
    
}