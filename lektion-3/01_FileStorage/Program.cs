using _01_FileStorage.Handlers;
using _01_FileStorage.Models;

var jsonHandler = new JsonHandler($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\customers.json");
var csvHandler = new CsvHandler($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\customers.csv");

void ReadFiles()
{
    try { jsonHandler.ReadFromFile(); } catch { }
    try { csvHandler.ReadFromFile(); } catch { }
}

void ListCustomers()
{
    Console.WriteLine("--- Json Customers ---");
    foreach(var customer in jsonHandler.Get()) { Console.WriteLine($"{customer.FirstName} {customer.LastName}"); }
    Console.WriteLine("");

    Console.WriteLine("--- CSV Customers ---");
    foreach (var customer in csvHandler.Get()) { Console.WriteLine($"{customer.FirstName} {customer.LastName}"); }
    Console.WriteLine("");
}

void WriteFiles()
{
    jsonHandler.WriteToFile();
    csvHandler.WriteToFile();   
}

void CreateCustomer()
{
    Console.WriteLine("--- New Customer ---");

    var customer = new Customer();
    Console.Write("FirstName: ");
        customer.FirstName = Console.ReadLine();
    Console.Write("LastName: ");
        customer.LastName = Console.ReadLine();
    Console.Write("Email: ");
        customer.Email = Console.ReadLine();   
    
    jsonHandler.Add(customer);
    csvHandler.Add(customer);
}



while(true)
{
    ReadFiles();
    ListCustomers();
    CreateCustomer();
    WriteFiles();
    Console.Clear();
}