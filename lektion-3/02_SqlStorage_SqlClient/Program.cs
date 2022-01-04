using _02_SqlStorage_SqlClient.Handlers;
using _02_SqlStorage_SqlClient.Models;

UserHandler userHandler = new UserHandler();

//var user = new User();
//Console.Write("Förnamn: ");
//user.FirstName = Console.ReadLine();
//Console.Write("Efternamn: ");
//user.LastName = Console.ReadLine();
//Console.Write("E-postadress: ");
//user.Email = Console.ReadLine();

//user.Address = new Address();
//Console.Write("Gata: ");
//user.Address.StreetName = Console.ReadLine();
//Console.Write("Postnummer: ");
//user.Address.PostalCode = Console.ReadLine();
//Console.Write("Stad: ");
//user.Address.City = Console.ReadLine();

//var userId = userHandler.CreateUser(user);
//Console.WriteLine("UserId: " + userId);

foreach(var user in userHandler.GetUsers())
    Console.WriteLine($"{user.FirstName} {user.LastName}");

Console.ReadKey();
