using System;
using System.Collections.Generic;
using System.Security;
using System.Threading;
using Confluent.Kafka;
using SourcedSharp.Core;
using SourcedSharp.Events;

namespace SourcedSharp.Implementations.Bus.Kafka
{
    public class KafkaEventListener
    {
        private IConsumer<string, string> _consumer { get; }
        private CancellationTokenSource _cancellationToken { get; set; }
        private Settings _settings { get; }
        public KafkaEventListener(Settings settings)
        {
            _settings = settings;
            _consumer = CreateConsumer();
        }

        public void Subscribe(Action<IEvent> eventHandler)
        {
            var topic = _settings.KafkaEventTopicName;
            _consumer.Subscribe(topic);

            _cancellationToken = new CancellationTokenSource();

            while (!_cancellationToken.IsCancellationRequested)
            {
                var consumeResult = _consumer.Consume(_cancellationToken.Token);
                //var @event = consumeResult.Message;
                //eventHandler(@event);
            }
        }

        public void Unsubscribe()
        {
            _cancellationToken.Cancel();
            _consumer.Close();
        }

        private IConsumer<string, string> CreateConsumer()
        {
            var config = new ConsumerConfig()
            {
                BootstrapServers = _settings.KafkaBrokerList,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            var consumer = new ConsumerBuilder<string, string>(config).Build();
            return consumer;
        }
    }
}