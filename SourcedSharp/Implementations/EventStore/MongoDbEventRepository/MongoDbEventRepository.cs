using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using SourcedSharp.Core.EventStore;
using SourcedSharp.Core.Exceptions;
using SourcedSharp.Core.Messages.Events;

namespace SourcedSharp.Implementations.EventStore.MongoDbAdapter
{
    public class MongoDbEventRepository : IEventRepository
    {
        private IMongoCollection<IEvent> _eventsCollection;
        private MongoClient _client;
        public MongoDbEventRepository(string connectionString, string dbName, string collectionName = "events")
        {
            _client = new MongoClient(connectionString);
            var database = _client.GetDatabase(dbName);
            _eventsCollection = database.GetCollection<IEvent>(collectionName);
        }

        public async Task<IEnumerable<IEvent>> GetEvents()
        {
            return await _eventsCollection.Find<IEvent>(FilterDefinition<IEvent>.Empty).ToListAsync();
        }

        public async Task CommitEvents(IEnumerable<IEvent> events)
        {
            using (var session = await _client.StartSessionAsync())
            {
                // Begin transaction
                session.StartTransaction();

                try
                {
                    await _eventsCollection.InsertManyAsync(events);
                    await session.CommitTransactionAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error writing to MongoDB: " + e.Message);
                    await session.AbortTransactionAsync();
                    throw new EventStoreException("Transaction did not succeed: reason - unknonw");// ToDo reason so that retries can be done, //Perhaps change exception class to optimistic consistency locking type
                }
            }
        }
    }
}