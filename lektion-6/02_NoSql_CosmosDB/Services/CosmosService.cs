using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_NoSql_CosmosDB.Services
{
    internal interface ICosmosService
    {
        Task<T> InsertRecordAsync<T>(string collection, T record, string partitionKey);
        Task<IEnumerable<T>> GetRecordsAsync<T>(string collection);
        Task<T> GetRecordAsync<T>(string collection, string id, string partitionKey);
        Task<T> UpdateRecordAsync<T>(string collection, string id, T record, string partitionKey);
        Task DeleteRecordAsync<T>(string collection, string id, string partitionKey);
    }

    internal class CosmosService : ICosmosService
    {
        private Database _database;
        private Container _container;

        public CosmosService()
        {
            Task.Run(async () => await ConnectAsync()).Wait();
        }

        private async Task ConnectAsync()
        {
            CosmosClient _cosmosClient = new CosmosClient(ConfigurationManager.AppSettings["EndPointUri"], ConfigurationManager.AppSettings["PrimaryKey"]);
            _database = await _cosmosClient.CreateDatabaseIfNotExistsAsync(ConfigurationManager.AppSettings["DatabaseName"]);
        }


        public async Task<T> InsertRecordAsync<T>(string collection, T record, string partitionKey)
        { 
            _container = await _database.CreateContainerIfNotExistsAsync(collection, "/partitionKey");
            return await _container.CreateItemAsync<T>(record, new PartitionKey(partitionKey));
        }

        public async Task<IEnumerable<T>> GetRecordsAsync<T>(string collection)
        {
            _container = _database.GetContainer(collection);
            FeedIterator<T> iterator = _container.GetItemQueryIterator<T>(new QueryDefinition("SELECT * FROM c"));

            List<T> records = new();
            while(iterator.HasMoreResults)
            {
                FeedResponse<T> result = await iterator.ReadNextAsync();
                foreach(T record in result)
                    records.Add(record);
            }

            return records;
        }

        public async Task<T> GetRecordAsync<T>(string collection, string id, string partitionKey)
        {
            _container = _database.GetContainer(collection);
            return await _container.ReadItemAsync<T>(id, new PartitionKey(partitionKey));
        }

        public async Task<T> UpdateRecordAsync<T>(string collection, string id, T record, string partitionKey)
        {
            _container = _database.GetContainer(collection);
            ItemResponse<T> item = await _container.ReadItemAsync<T>(id, new PartitionKey(partitionKey));
            var itemContent = item.Resource;
            itemContent = record;

            return await _container.ReplaceItemAsync<T>(itemContent, id, new PartitionKey(partitionKey));
        }

        public async Task DeleteRecordAsync<T>(string collection, string id, string partitionKey)
        {
            _container = _database.GetContainer(collection);
            await _container.DeleteItemAsync<T>(id, new PartitionKey(partitionKey));
        }
    }
}
