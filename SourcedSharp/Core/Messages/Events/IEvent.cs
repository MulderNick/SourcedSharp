using System;

namespace SourcedSharp.Core.Messages.Events
{
    /*
     * An event is responsible for transporting occured facts
     */
    public interface IEvent : IMessage
    {
        EventMetaData MetaData { get; set;  }
    }
}