using System.Collections.Generic;

namespace SourcedSharp.Core.Messages.Events
{
    public interface IEventHandler
    {
        void ApplyEvents(IEnumerable<IEvent> events);
        void ApplyEvent(IEvent @event);
    }
}