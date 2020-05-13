using System.Threading.Tasks;
using Confluent.Kafka;
using SourcedSharp.Core;
using SourcedSharp.Events;
using SourcedSharp.MessageBus;

namespace SourcedSharp.Implementations.Bus.Kafka
{
    public class KafkaEventPublisher : IEventBus
    {
        private IProducer<string, string> _producer { get;  }
        private Settings _settings { get;  }
        public KafkaEventPublisher(Settings settings)
        {
            _settings = settings;
            _producer = CreateProducer();
        }

        public async Task<DeliveryResult<string, string>> EmitEvent(IEvent @event)
        {
            var value = "";
            var message = new Message<string, string>()
            {
                Value = value
            };
            var result = await ProduceMessageAsync(message);
            return result;
        }
        public async Task<DeliveryResult<string, string>> EmitString(string value)
        {
            var message = new Message<string, string>()
            {
                Value = value
            };
            var result = await ProduceMessageAsync(message);
            return result;
        }

        private async Task<DeliveryResult<string, string>> ProduceMessageAsync(Message<string, string> message)
        {
            var topic = _settings.KafkaEventTopicName;
            var result = await _producer.ProduceAsync(topic, message);
            return result;
        }

        private IProducer<string, string> CreateProducer()
        {
            var config = new ProducerConfig
            {
                BootstrapServers = _settings.KafkaBrokerList,
                Acks = Acks.All
            };
            var producer = new ProducerBuilder<string, string>(config).Build();
            return producer;
        }
    }
}