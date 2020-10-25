using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SourcedSharp.Core.Messages.Events
{
    public class MountedEventHandler : IEventHandler
    {
        // ToDo: see if the strings below can be generated during runtime, this might decrease overhead during changes
        private static string _eventSubscriptionInterfaceName = "IApply`1";
        private static string _eventSubscriptionFunctionName = "Apply";
        private readonly object _mountedInstance;
        private Dictionary<Type, MethodInfo> EventHandlers = new Dictionary<Type, MethodInfo>();
        public int NumberOfInvokedHandlers { get; set; }
        public int NumberOfEventsHandled { get; set; }
        public IEvent LastHandledEvent;

        public MountedEventHandler(object mountedInstance)
        {
            _mountedInstance = mountedInstance;
            PrepareHandlers();
        }

        public void ApplyEvents(IEnumerable<IEvent> events)
        {
            foreach (var @event in events)
            {
                ApplyEvent(@event);
            }
        }

        public void ApplyEvent(IEvent @event)
        {
            NumberOfEventsHandled++;
            LastHandledEvent = @event;

            var eventType = @event.GetType();
            var isHandlerAvailable = EventHandlers.TryGetValue(eventType, out var eventHandler);

            if (isHandlerAvailable)
            {
                NumberOfInvokedHandlers++;
                eventHandler.Invoke(_mountedInstance, new[] {@event});
            }
        }

        protected void PrepareHandlers()
        {
            var type = _mountedInstance.GetType();
            var methods = type.GetMethods();
            var subscribedEvents = type.GetInterfaces().Where(i => i.Name.Equals(_eventSubscriptionInterfaceName)).Select(i => i.GenericTypeArguments.FirstOrDefault()).ToList();
            foreach (var subscribedEvent in subscribedEvents)
            {
                var handler = methods.First(m => 
                    m.Name.Equals(_eventSubscriptionFunctionName) &&
                    m.GetParameters().Length == 1 &&
                    m.GetParameters().Count( p => p.ParameterType == subscribedEvent) == 1);
                EventHandlers.Add(subscribedEvent, handler);
            }
        }
    }
}