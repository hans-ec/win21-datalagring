using _04_NoSql.Handlers;
using _04_NoSql.Models;


await MongoDbExample();
await CosmosDbExample();



async Task MongoDbExample()
{
    Console.WriteLine("");
    Console.WriteLine("--- MongoDB Example ---");

    var userModel = new UserModel() { PartitionKey = "Users", Id = Guid.NewGuid(), FirstName = "Hans", LastName = "Mattin-Lassei", Email = "hans@domain.com" };  
    var mongoManager = new MongoDbManager("WIN21", "mongodb+srv://win21:BytMig123@cluster0.rdmoj.mongodb.net/WIN21?retryWrites=true&w=majority");

    await mongoManager.AddAsync<UserModel>("Users", userModel);

    foreach (var user in await mongoManager.GetAsync<UserModel>("Users"))
        Console.WriteLine($"{user.Id}: {user.FirstName} {user.LastName} ({user.Email})");
}

async Task CosmosDbExample()
{
    Console.WriteLine("");
    Console.WriteLine("--- CosmosDB Example ---");

    var userModel = new UserModel() { PartitionKey = "Users", Id = Guid.NewGuid(), FirstName = "Hans", LastName = "Mattin-Lassei", Email = "hans@domain.com" };
    var cosmosManger = new CosmosDbManager("WIN21", "AccountEndpoint=https://win21-cosmosdb.documents.azure.com:443/;AccountKey=jgsT9LefqVO9DTnPTFBFR4L0VHe00xgbyurCSImmpcM1xDvnlIMK9TS9gEpqXfqCwyijp4RinWuYY6i3V9aohA==;");

    await cosmosManger.AddAsync("Users", userModel);

    foreach(var user in await cosmosManger.GetAsync<UserModel>("Users"))
        Console.WriteLine($"{user.Id}: {user.FirstName} {user.LastName} ({user.Email})");
}