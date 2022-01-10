using _01_NoSql_MongoDB.Models;
using _01_NoSql_MongoDB.Services;

var customer = new Customer()
{
    FirstName = "Hans",
    LastName = "Mattin-Lassei",
    Email = "hans@domain.com",
    Address = new Address
    {
        StreetName = "Nordkapsvägen 1",
        PostalCode = "13657",
        City = "Vega"
    }
};


IMongoService mongodb = new MongoService("WIN21");

//mongodb.InsertRecord<Customer>("Customers", customer);

//var records = mongodb.GetAllRecords<Customer>("Customers");
//foreach(var item in records)
//    Console.WriteLine($"{item.Id} : {item.FirstName} {item.LastName}. {item.Address.StreetName}, {item.Address.PostalCode} {item.Address.City}");

var read_record = mongodb.GetRecord<Customer>("Customers", new Guid("8d5cfb28-c058-4c86-99b7-b94f5a315fba"));
Console.WriteLine($"{read_record.Id} : {read_record.FirstName} {read_record.LastName}. {read_record.Address.StreetName}, {read_record.Address.PostalCode} {read_record.Address.City}");

read_record.FirstName = "Tommy";
read_record.Email = "tommy@domain.com";
mongodb.UpdateRecord("Customers", read_record.Id, read_record);
Console.WriteLine($"{read_record.Id} : {read_record.FirstName} {read_record.LastName}. {read_record.Address.StreetName}, {read_record.Address.PostalCode} {read_record.Address.City}");

mongodb.DeleteRecord<Customer>("Customers", new Guid("8d5cfb28-c058-4c86-99b7-b94f5a315fba"));