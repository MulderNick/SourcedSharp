using System;

namespace SourcedSharp.Core.Messages.Events
{
    public class Event : IEvent
    {
        public Event()
        {
            MetaData = new EventMetaData();
        }

        public EventMetaData MetaData { get; set; }
    }
}