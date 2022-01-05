using _02_EntityFrameworkCore_DatabaseFirst.Data;
using _02_EntityFrameworkCore_DatabaseFirst.Entities;
using _02_EntityFrameworkCore_DatabaseFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_EntityFrameworkCore_DatabaseFirst.Services
{
    internal class UserService
    {
        private SqlContext _context = new SqlContext();

        public void CreateUser(UserModel user)
        {
            var _user = _context.Users.Where(x => x.Email == user.Email).FirstOrDefault();

            if (_user == null)
            {
                var address = _context.Addresses
                    .Where(x => x.StreetName == user.StreetName && x.PostalCode == user.PostalCode)
                    .FirstOrDefault();

                if (address == null)
                {
                    address = new Address() { StreetName = user.StreetName, PostalCode = user.PostalCode, City = user.City };
                    _context.Addresses.Add(address);
                    _context.SaveChanges();
                }

                _context.Users.Add(new User { FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, AddressId = address.Id });
                _context.SaveChanges();
            }

        }
    }
}
