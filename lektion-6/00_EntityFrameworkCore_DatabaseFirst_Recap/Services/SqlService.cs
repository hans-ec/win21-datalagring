using _00_EntityFrameworkCore_DatabaseFirst_Recap.Data;
using _00_EntityFrameworkCore_DatabaseFirst_Recap.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_EntityFrameworkCore_DatabaseFirst_Recap.Services
{
    internal class SqlService
    {
        private readonly SqlContext _context = new SqlContext();

        #region Create

        public int CreateAddress(Address address)
        {
            
            var _address = _context.Addresses.Where(x => x.StreetName == address.StreetName && x.PostalCode == address.PostalCode && x.City == address.City && x.Country == address.Country).FirstOrDefault();
            
            if (_address == null)
            {
                _context.Addresses.Add(address);
                _context.SaveChanges();
                return address.Id;
            }

            return _address.Id;
        }

        public int CreateCustomer(CreateCustomer customer)
        {
            var _customer = new Customer();
            var item = _context.Customers.Where(x => x.Email == customer.Email).FirstOrDefault();

            if (item == null)
            {
                _customer.FirstName = customer.FirstName;
                _customer.LastName = customer.LastName;
                _customer.Email = customer.Email;
                _customer.AddressId = CreateAddress(customer.Address);

                _context.Customers.Add(_customer);
                _context.SaveChanges();
            }  
            
            return _customer.Id;
        }

        #endregion

        #region Read

        public Address GetAddress(int id)
        {
            return _context.Addresses.SingleOrDefault(x => x.Id == id);
        }

        public Customer GetCustomer(int id)
        {
            return _context.Customers.Include(x => x.Address).SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Address> GetAddresses()
        {
            return _context.Addresses;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.Include(x => x.Address).ToList();
        }

        #endregion

        #region Update

        public void UpdateAddress(int id, Address address)
        {
            var item = _context.Addresses.Find(id);
            
            if(item != null && item.Id == id)
            {
                item.StreetName = address.StreetName;
                item.PostalCode = address.PostalCode;
                item.City = address.City;
                item.Country = address.Country;

                _context.Update(item);
                _context.SaveChanges();
            }
        }

        public void UpdateCustomer(int id, Customer customer)
        {
            var item = _context.Customers.Find(id);

            if (item != null && item.Id == id)
            {
                item.FirstName = customer.FirstName;
                item.LastName = customer.LastName;
                item.Email = customer.Email;
                item.AddressId = customer.AddressId;

                _context.Update(item);
                _context.SaveChanges();
            }
        }

        #endregion

        #region Delete

        public void DeleteAddress(int id)
        {
            var item = _context.Addresses.Find(id);
            if (item != null && item.Id == id)
            {
                _context.Remove(item);
                _context.SaveChanges();
            } 
        }
        public void DeleteCustomer(int id)
        {
            var item = _context.Customers.Find(id);
            if (item != null && item.Id == id)
            {
                _context.Remove(item);
                _context.SaveChanges();
            }
        }

        #endregion
    }
}
