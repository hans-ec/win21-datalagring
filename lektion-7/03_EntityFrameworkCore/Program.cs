using _03_EntityFrameworkCore.Handlers;
using _03_EntityFrameworkCore.Models;

EntityFrameworkCoreExample();



void EntityFrameworkCoreExample()
{
    var userModel = new UserModel() { Id = Guid.NewGuid(), FirstName = "Hans", LastName = "Mattin-Lassei", Email = "hans@domain.com" };

    Console.WriteLine("");
    Console.WriteLine("--- Entity Framework Core Example ---");

    UserManager userManager = new UserManager();

    foreach (var user in userManager.Get())
        Console.WriteLine($"{user.Id}: {user.FirstName} {user.LastName} ({user.Email})");

    userManager.Add(userModel);

}