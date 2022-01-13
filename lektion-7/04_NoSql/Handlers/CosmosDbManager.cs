using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_NoSql.Handlers
{
    internal class CosmosDbManager : DataHandler
    {
        private string _endpoint;
        private string _primaryKey;
        private Database _database;
        private Container _container;


        public CosmosDbManager(string databaseName, string connectionstring = "", string endpoint = "", string primaryKey = "")
        {
            _databaseName = databaseName;
            _connectionString = connectionstring;

            _endpoint = endpoint;
            _primaryKey = primaryKey;

            ConnectAsync().Wait();
        }

        private async Task ConnectAsync()
        {
            CosmosClient _cosmosClient = new CosmosClient(_connectionString);
            _database = await _cosmosClient.CreateDatabaseIfNotExistsAsync(_databaseName);
        }


        public override async Task AddAsync<T>(string collectionName, T record)
        {
            _container = await _database.CreateContainerIfNotExistsAsync(collectionName, "/partitionKey");
            var data = await _container.CreateItemAsync<T>(record, new PartitionKey("Users"));
        }

        public override async Task<IEnumerable<T>> GetAsync<T>(string collectionName)
        {
            _container = _database.GetContainer(collectionName);
            FeedIterator<T> iterator = _container.GetItemQueryIterator<T>(new QueryDefinition("SELECT * FROM c"));

            List<T> records = new();
            while (iterator.HasMoreResults)
            {
                FeedResponse<T> result = await iterator.ReadNextAsync();
                foreach (T record in result)
                    records.Add(record);
            }

            return records;
        }
    }
}
