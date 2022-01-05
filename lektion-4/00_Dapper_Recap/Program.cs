using _00_Dapper_Recap.Entitites;
using _00_Dapper_Recap.Services;

IUserService userService = new UserService();



Console.WriteLine("--- Skapa en ny användare ---");
if (userService.CreateUser(new User { FirstName = "Haithem", LastName = "Smirani", Email = "haithem@domain.com" }))
    Console.WriteLine("En ny användare har skapats. \n");
else
    Console.WriteLine("En användare med samma e-postadress finns redan.\n");




Console.WriteLine("--- Lista med alla användare ---");
foreach (var user in userService.GetUsers())
    Console.WriteLine($"{user.FirstName} {user.LastName} ({user.Email})");
