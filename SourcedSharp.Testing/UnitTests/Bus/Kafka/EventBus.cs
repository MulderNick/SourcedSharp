using System;
using System.Threading.Tasks;
using NUnit.Framework;
using SourcedSharp.Core;
using SourcedSharp.Implementations.Bus.Kafka;

namespace SourcedSharp.Testing.UnitTests.Bus.Kafka
{
    public class EventBusTest
    {
        private KafkaEventPublisher _eventBus { get; set; }
        private Settings _settings { get; set; }

        [SetUp]
        public void SetUp()
        {
            _settings = new Settings();
            _eventBus = new KafkaEventPublisher(_settings);
        }

        [Test]
        public async Task EmitEventTest()
        {
            var result = await _eventBus.EmitString("test1");
            Assert.True(result.Key == "");
        }

        //[Test]
        //public Task SubscribeToEvent()
        //{
        //    //_eventBus.s
        //    //var result = await _eventBus.EmitString("test2");
        //    //Assert.True(result.Key == "");
        //}
    }
}