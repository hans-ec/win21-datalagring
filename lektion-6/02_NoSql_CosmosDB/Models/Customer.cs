using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_NoSql_CosmosDB.Models
{
    internal class Customer
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [JsonProperty(PropertyName = "partitionKey")]
        public string PartitionKey { get; set; } = "Customer";
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public Address Address { get; set; } = new Address();

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
