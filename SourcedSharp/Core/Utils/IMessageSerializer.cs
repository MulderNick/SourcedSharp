using SourcedSharp.Messages;

namespace SourcedSharp.Core.Utils
{
    public interface IMessageSerializer
    {
        string Serialize(IMessage message);
        IMessage Serialize(string message);
    }
}