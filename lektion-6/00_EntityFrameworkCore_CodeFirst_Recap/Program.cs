using _00_EntityFrameworkCore_CodeFirst_Recap.Models;
using _00_EntityFrameworkCore_CodeFirst_Recap.Services;

Customer customer = new Customer
{
    FirstName = "Anna",
    LastName = "Mattin-Lassei",
    Email = "anna@domain.com",
    Address = new Address
    {
        StreetName = "Nordkapsvägen 2",
        PostalCode = "13657",
        City = "Vega",
        Country = "Sverige"
    }
};

SqlService sql = new SqlService();

var customerId = sql.CreateCustomer(customer);

var read_customer = sql.GetCustomer(customerId);
Console.WriteLine($"{read_customer.Id} : {read_customer.FirstName} {read_customer.LastName}\n{read_customer.Address.StreetName}, {read_customer.Address.PostalCode} {read_customer.Address.City}");