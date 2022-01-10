using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_NoSql_MongoDB.Services
{
    internal interface IMongoService
    {
        void InsertRecord<T>(string collection, T record);
        IEnumerable<T> GetAllRecords<T>(string collection);
        T GetRecord<T>(string collection, Guid id);
        void UpdateRecord<T>(string collection, Guid id, T recrod);
        void DeleteRecord<T>(string collection, Guid id);
    }

    internal class MongoService : IMongoService
    {
        private IMongoDatabase _database;

        public MongoService(string databaseName)
        {
            var settings = MongoClientSettings.FromConnectionString($"mongodb+srv://win21:BytMig123!@cluster0.odhdn.mongodb.net/{databaseName}?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            _database = client.GetDatabase(databaseName);
        }

        public void DeleteRecord<T>(string collection, Guid id)
        {
            var _collection = _database.GetCollection<T>(collection);
            _collection.DeleteOne(Builders<T>.Filter.Eq("Id", id));
        }

        public IEnumerable<T> GetAllRecords<T>(string collection)
        {
            var _collection = _database.GetCollection<T>(collection);
            return _collection.Find(new BsonDocument()).ToList();
        }

        public T GetRecord<T>(string collection, Guid id)
        {
            var _collection = _database.GetCollection<T>(collection);
            return _collection.Find(Builders<T>.Filter.Eq("Id", id)).FirstOrDefault();
        }

        public void InsertRecord<T>(string collection, T record)
        {
            var _collection = _database.GetCollection<T>(collection);
            _collection.InsertOne(record);
        }

        public void UpdateRecord<T>(string collection, Guid id, T record)
        {
            var _collection = _database.GetCollection<T>(collection);
            var result = _collection.ReplaceOne(new BsonDocument("_id", id), record, new UpdateOptions { IsUpsert = true });
        }
    }
}
