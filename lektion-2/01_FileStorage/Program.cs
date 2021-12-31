using _01_FileStorage.Abstracts;
using _01_FileStorage.Handlers;
using _01_FileStorage.Models;


Console.WriteLine("------------ CSV EXEMPEL ------------");

ICsvHandler csvHandler = new CsvHandler();

/* Försök att hämta kunder från filen customer-list.csv */
try { csvHandler.ReadFromFile($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\customer-list.csv"); }
catch { }

/* Lägg till en kund i listan och spara sedan listan till filen customer-list.csv */
csvHandler.AddToList(new Customer { Id = 1, FirstName = "Hans", LastName = "Mattin-Lassei", Email = "hans@domain.com" });
csvHandler.SaveToFile($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\customer-list.csv");

/* Hämta listan och skriv ut den i konsolen */
foreach (var customer in csvHandler.Customers())
    Console.WriteLine($"{customer.FirstName} {customer.LastName}");






Console.WriteLine();
Console.WriteLine("------------ JSON EXEMPEL ------------");

IJsonHandler jsonHandler = new JsonHandler();

/* Försök att hämta kunder från filen customer-list.json */
try { jsonHandler.ReadFromFile($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\customer-list.json"); }
catch { }

/* Lägg till en kund i listan och spara sedan listan till filen customer-list.json */
jsonHandler.AddToList(new Customer { Id = 1, FirstName = "Hans", LastName = "Mattin-Lassei", Email = "hans@domain.com" });
jsonHandler.SaveToFile($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\customer-list.json");

/* Hämta listan och skriv ut den i konsolen */
foreach (var customer in jsonHandler.Customers())
    Console.WriteLine($"{customer.FirstName} {customer.LastName}");






Console.WriteLine();
Console.WriteLine("------------ CSV ABSTRACT EXEMPEL ------------");

CsvAbstractHandler csvAbstractHandler = new CsvAbstractHandler();

/* Försök att hämta kunder från filen customer-list-abstract.csv */
try { csvAbstractHandler.ReadFromFile($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\customer-list-abstract.csv"); }
catch { }

/* Lägg till en kund i listan och spara sedan listan till filen customer-list-abstract.csv */
csvAbstractHandler.AddToList(new Customer { Id = 1, FirstName = "Hans", LastName = "Mattin-Lassei", Email = "hans@domain.com" });
csvAbstractHandler.SaveToFile($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\customer-list-abstract.csv");

/* Hämta listan och skriv ut den i konsolen */
foreach (var customer in csvAbstractHandler.Customers())
    Console.WriteLine($"{customer.FirstName} {customer.LastName}");






Console.WriteLine();
Console.WriteLine("------------ JSON ABSTRACT EXEMPEL ------------");

JsonAbstractHandler jsonAbstractHandler = new JsonAbstractHandler();

/* Försök att hämta kunder från filen customer-list-abstract.json */
try { jsonAbstractHandler.ReadFromFile($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\customer-list-abstract.json"); }
catch { }

/* Lägg till en kund i listan och spara sedan listan till filen customer-list-abstract.json */
jsonAbstractHandler.AddToList(new Customer { Id = 1, FirstName = "Hans", LastName = "Mattin-Lassei", Email = "hans@domain.com" });
jsonAbstractHandler.SaveToFile($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\customer-list-abstract.json");

/* Hämta listan och skriv ut den i konsolen */
foreach (var customer in jsonAbstractHandler.Customers())
    Console.WriteLine($"{customer.FirstName} {customer.LastName}");