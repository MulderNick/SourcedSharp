using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using SourcedSharp.Core.Utils;
using SourcedSharp.Messages;

namespace SourcedSharp.Implementations
{
    public class JsonMessageSerializer : IMessageSerializer
    {
        private JsonSerializer _serializer { get;  }
        public JsonMessageSerializer()
        {
            _serializer = getSerializer();
        }
        public string Serialize(IMessage message)
        {
            return "";
        }

        public IMessage Serialize(string message)
        {
            throw new System.NotImplementedException();
        }

        private JsonSerializer getSerializer()
        {
            var res = new JsonSerializer
            {
                PreserveReferencesHandling = PreserveReferencesHandling.None,
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                ObjectCreationHandling = ObjectCreationHandling.Replace,
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                Culture = CultureInfo.GetCultureInfo("en-US"),
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                FloatParseHandling = FloatParseHandling.Decimal,
                Formatting = Formatting.None,
            };

            res.Converters.Add(new StringEnumConverter());
            return res;
        }
    }
}