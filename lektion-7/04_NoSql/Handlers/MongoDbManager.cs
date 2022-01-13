using _04_NoSql.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_NoSql.Handlers
{
    internal class MongoDbManager : DataHandler
    {
        private IMongoDatabase _database;

        public MongoDbManager(string databaseName, string connectionstring)
        {
            _databaseName = databaseName;
            _connectionString = connectionstring;

            var settings = MongoClientSettings.FromConnectionString(_connectionString);
            var client = new MongoClient(settings);
            _database = client.GetDatabase(_databaseName);
        }

        public override async Task AddAsync<T>(string collectionName, T record)
        {
            var _collection = _database.GetCollection<T>(collectionName);
            await _collection.InsertOneAsync(record);
        }

        public override async Task<IEnumerable<T>> GetAsync<T>(string collectionName)
        {
            var _collection = _database.GetCollection<T>(collectionName);
            var result = await _collection.FindAsync(new BsonDocument());
            return await result.ToListAsync();
        }
    }
}
