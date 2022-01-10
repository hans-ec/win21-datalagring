using _00_EntityFrameworkCore_CodeFirst_Recap.Data;
using _00_EntityFrameworkCore_CodeFirst_Recap.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_EntityFrameworkCore_CodeFirst_Recap.Services
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
                var addressEntity = new AddressEntity { StreetName= address.StreetName, PostalCode = address.PostalCode,City = address.City, Country = address.Country };

                _context.Addresses.Add(addressEntity);
                _context.SaveChanges();
                return addressEntity.Id;
            }

            return _address.Id;
        }

        public int CreateCustomer(Customer customer)
        {
            
            var _customer = _context.Customers.Where(x => x.Email == customer.Email).FirstOrDefault();

            if (_customer == null)
            {
                var customerEntity = new CustomerEntity();

                customerEntity.FirstName = customer.FirstName;
                customerEntity.LastName = customer.LastName;
                customerEntity.Email = customer.Email;
                customerEntity.AddressId = CreateAddress(customer.Address);

                _context.Customers.Add(customerEntity);
                _context.SaveChanges();

                return customerEntity.Id;
            }

            return _customer.Id;
        }

        #endregion

        #region Read

        public AddressEntity GetAddress(int id)
        {
            return _context.Addresses.SingleOrDefault(x => x.Id == id);
        }

        public CustomerEntity GetCustomer(int id)
        {
            return _context.Customers.Include(x => x.Address).SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<AddressEntity> GetAddresses()
        {
            return _context.Addresses;
        }

        public IEnumerable<CustomerEntity> GetCustomers()
        {
            return _context.Customers.Include(x => x.Address).ToList();
        }

        #endregion

        #region Update

        public void UpdateAddress(int id, AddressEntity address)
        {
            var item = _context.Addresses.Find(id);

            if (item != null && item.Id == id)
            {
                item.StreetName = address.StreetName;
                item.PostalCode = address.PostalCode;
                item.City = address.City;
                item.Country = address.Country;

                _context.Update(item);
                _context.SaveChanges();
            }
        }

        public void UpdateCustomer(int id, CustomerEntity customer)
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
