using _02_SqlStorage.Handlers;
using _02_SqlStorage.Models;

SqlClientExample();
DapperExample();





void SqlClientExample()
{
    var userModel = new UserModel() { Id = Guid.NewGuid(), FirstName = "Hans", LastName = "Mattin-Lassei", Email = "hans@domain.com" };

    Console.WriteLine("");
    Console.WriteLine("--- SqlClient Example ---");

    var sqlClientManager = new SqlClientManager(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\WIN21\win21-datalagring\lektion-7\02_SqlStorage\Data\sql_db.mdf;Integrated Security=True;Connect Timeout=30");

    foreach (var user in sqlClientManager.Get())
        Console.WriteLine($"{user.Id}: {user.FirstName} {user.LastName} ({user.Email})");

    sqlClientManager.Add(userModel);

}

void DapperExample()
{
    var userModel = new UserModel() { Id = Guid.NewGuid(), FirstName = "Hans", LastName = "Mattin-Lassei", Email = "hans@domain.com" };

    Console.WriteLine("");
    Console.WriteLine("--- Dapper Example ---");

    var dapperManager = new DapperManager(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\WIN21\win21-datalagring\lektion-7\02_SqlStorage\Data\sql_db.mdf;Integrated Security=True;Connect Timeout=30");

    foreach (var user in dapperManager.Get())
        Console.WriteLine($"{user.Id}: {user.FirstName} {user.LastName} ({user.Email})");

    dapperManager.Add(userModel);

}