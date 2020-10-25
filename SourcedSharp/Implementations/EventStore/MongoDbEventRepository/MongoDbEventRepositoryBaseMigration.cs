using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MongoDB.Driver;
using SourcedSharp.Core.Messages.Events;

namespace SourcedSharp.Implementations.EventStore.MongoDbAdapter
{
    public class MongoDbEventRepositoryBaseMigration
    {
        private string _connectionString;
        private string _dbName;
        private string _collectionName;
        private MongoClient _client;
        private IMongoDatabase _database;
        private IMongoCollection<Event> _eventsCollection;
        public MongoDbEventRepositoryBaseMigration(string connectionString, string dbName, string collectionName = null)
        {
            _connectionString = connectionString;
            _dbName = dbName;
            _collectionName = collectionName ?? "events";
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(_dbName);
            _eventsCollection = _database.GetCollection<Event>(_collectionName);

        }
        public static async Task Run(string connectionString, string dbName, string collectionName = null)
        {
            var migration = new MongoDbEventRepositoryBaseMigration(connectionString, dbName, collectionName);
            //await migration.CreateCollectionIfNotExists();
            await migration.CreateCollectionIndex();
        }

        public async Task CreateCollectionIfNotExists()
        {
            await _database.CreateCollectionAsync(_collectionName);
        }
        
        public async Task CreateCollectionIndex()
        {
            var options = new CreateIndexOptions() { Unique = true };
            var indexKeysDefinition = Builders<Event>.IndexKeys.Ascending(@event => @event.MetaData.AggregateId)
                .Ascending(@event => @event.MetaData.AggregateVersion);
            await _eventsCollection.Indexes.CreateOneAsync(new CreateIndexModel<Event>(indexKeysDefinition, options));
        }
    }
}