using _01_FileStorage.Handlers;
using _01_FileStorage.Models;


XmlExample();
CsvExample();
JsonExample();





void XmlExample()
{
    var userModel = new UserModel() { Id = Guid.NewGuid().ToString(), Name = "Hans Mattin-Lassei", Email = "hans@domain.com" };

    Console.WriteLine("");
    Console.WriteLine("--- XML Example ---");

    var xmlFileManager = new XmlFileManager(@$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\files\users.xml");
    xmlFileManager.ReadFromFile();

    foreach (var user in xmlFileManager.Get())
        Console.WriteLine($"{user.Id}: {user.Name} ({user.Email})");

    xmlFileManager.Add(userModel);
    xmlFileManager.WriteToFile();
}

void CsvExample()
{
    var userModel = new UserModel() { Id = Guid.NewGuid().ToString(), Name = "Hans Mattin-Lassei", Email = "hans@domain.com" };

    Console.WriteLine("");
    Console.WriteLine("--- CSV Example ---");

    var csvFileManager = new CsvFileManager(@$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\files\users.csv");
    csvFileManager.ReadFromFile();

    foreach(var user in csvFileManager.Get())
        Console.WriteLine($"{user.Id}: {user.Name} ({user.Email})");

    csvFileManager.Add(userModel);
    csvFileManager.WriteToFile();
}

void JsonExample()
{
    var userModel = new UserModel() { Id = Guid.NewGuid().ToString(), Name = "Hans Mattin-Lassei", Email = "hans@domain.com" };

    Console.WriteLine("");
    Console.WriteLine("--- Json Example ---");

    var jsonFileManager = new JsonFileManager(@$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\files\users.json");
    jsonFileManager.ReadFromFile();

    foreach (var user in jsonFileManager.Get())
        Console.WriteLine($"{user.Id}: {user.Name} ({user.Email})");

    jsonFileManager.Add(userModel);
    jsonFileManager.WriteToFile();
}