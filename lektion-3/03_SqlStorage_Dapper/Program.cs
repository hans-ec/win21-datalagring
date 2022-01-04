using _03_SqlStorage_Dapper.Handlers;
using _03_SqlStorage_Dapper.Models;

UserHandler userHandler = new UserHandler();

var userId = userHandler.Create(new User
{
    FirstName = "m",
    LastName = "m",
    Email = "m22",
    StreetName = "m",
    PostalCode = "m",
    City = "m"
});

foreach(var u in userHandler.ReadAll())
    Console.WriteLine($"{u.FirstName} {u.LastName}, {u.StreetName} {u.PostalCode} {u.City}");

Console.WriteLine("");
userHandler.Update(new User
{
    Id = userId,
    FirstName = "Hans",
    LastName = "Mattin-Lassei",
    Email = "hans@domain.com",
    StreetName = "Nordkapsvägen 1",
    PostalCode = "13657",
    City = "Vega"
});

foreach (var u in userHandler.ReadAll())
    Console.WriteLine($"{u.FirstName} {u.LastName}, {u.StreetName} {u.PostalCode} {u.City}");

Console.WriteLine("");
userHandler.Delete(userId);

foreach (var u in userHandler.ReadAll())
    Console.WriteLine($"{u.FirstName} {u.LastName}, {u.StreetName} {u.PostalCode} {u.City}");



