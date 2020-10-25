using System;

namespace SourcedSharp.Core.Exceptions
{
    public class EventStoreException : Exception
    {
        public EventStoreException(string message) : base(message)
        {

        }
    }
}