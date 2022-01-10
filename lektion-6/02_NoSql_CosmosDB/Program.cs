using _02_NoSql_CosmosDB.Models;
using _02_NoSql_CosmosDB.Services;

namespace _02_NoSql_CosmosDB
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var customer = new Customer()
            {
                FirstName = "Tommy",
                LastName = "Mattin-Lassei",
                Email = "tommy@domain.com",
                Address = new Address
                {
                    StreetName = "Nordkapsvägen 1",
                    PostalCode = "13657",
                    City = "Vega"
                }
            };

            ICosmosService cosmos = new CosmosService();
            var insert_result = await cosmos.InsertRecordAsync("Customers", customer, customer.PartitionKey);
            Console.WriteLine($"{insert_result.Id} : {insert_result.FirstName} {insert_result.LastName}. {insert_result.Address.StreetName}, {insert_result.Address.PostalCode} {insert_result.Address.City}");

            var get_results = await cosmos.GetRecordsAsync<Customer>("Customers");
            foreach(var result in get_results) 
                Console.WriteLine($"{result.Id} : {result.FirstName} {result.LastName}. {result.Address.StreetName}, {result.Address.PostalCode} {result.Address.City}");

            var get_result = await cosmos.GetRecordAsync<Customer>("Customers", "e3040436-5831-4792-9a67-c3bc1365364f", "Customer");
            Console.WriteLine($"{get_result.Id} : {get_result.FirstName} {get_result.LastName}. {get_result.Address.StreetName}, {get_result.Address.PostalCode} {get_result.Address.City}");

            get_result.LastName = "Andersson Andersson";
            var updated_result = await cosmos.UpdateRecordAsync<Customer>("Customers", get_result.Id, get_result, get_result.PartitionKey);
            Console.WriteLine($"{updated_result.Id} : {updated_result.FirstName} {updated_result.LastName}. {updated_result.Address.StreetName}, {updated_result.Address.PostalCode} {updated_result.Address.City}");

            await cosmos.DeleteRecordAsync<Customer>("Customers", updated_result.Id, updated_result.PartitionKey);
        }
    }
}