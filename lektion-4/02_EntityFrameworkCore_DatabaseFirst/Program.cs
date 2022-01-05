using _02_EntityFrameworkCore_DatabaseFirst.Entities;
using _02_EntityFrameworkCore_DatabaseFirst.Models;
using _02_EntityFrameworkCore_DatabaseFirst.Services;

UserService userService = new UserService();

var user = new UserModel()
{
    FirstName = "Angasdfasdfelica",
    LastName = "Mattin-Lassei",
    Email = "bbbbba@domain.com",
    StreetName = "vägen 3",
    PostalCode = "13657",
    City = "Vega"
};

userService.CreateUser(user);
