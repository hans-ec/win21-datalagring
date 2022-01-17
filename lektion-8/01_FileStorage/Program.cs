using _01_FileStorage.Models;
using _01_FileStorage.Services;

// SOLID - Design Pattern
JsonFileService _fileService = new JsonFileService();



var users = new List<UserModel>() 
{
    new UserModel { Id = 1, FirstName = "Hans", LastName = "Mattin-Lassei" },
    new UserModel { Id = 2, FirstName = "Tommy", LastName = "Mattin-Lassei" },
    new UserModel { Id = 3, FirstName = "Joakim", LastName = "Wahlström" }
};
string usersFilePath = @"C:\Users\HansMattin-Lassei\Desktop\demo\users.json";
await _fileService.SaveToFileAsync(users, usersFilePath);

var products = new List<ProductModel>()
{
    new ProductModel { Id = 1, Name = "Product 1"},
    new ProductModel { Id = 2, Name = "Product 2"},
    new ProductModel { Id = 3, Name = "Product 3"},
};
string productsFilePath = @"C:\Users\HansMattin-Lassei\Desktop\demo\products.json";
await _fileService.SaveToFileAsync(products, productsFilePath);



foreach (var item in await _fileService.ReadFromFileAsync<UserModel>(usersFilePath))
    Console.WriteLine($"{item.FirstName} {item.LastName}");

foreach (var item in await _fileService.ReadFromFileAsync<ProductModel>(productsFilePath))
    Console.WriteLine($"{item.Name}");
