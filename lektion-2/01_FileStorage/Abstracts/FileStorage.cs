using _01_FileStorage.Interfaces;
using _01_FileStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_FileStorage.Abstracts
{
    public abstract class FileStorage
    {
        protected List<Customer> _customers = new List<Customer>();

        public void AddToList(Customer customer)
        {
            _customers.Add(customer);
        }

        public List<Customer> Customers()
        {
            return _customers;
        }

        public abstract void ReadFromFile(string filePath);

        public abstract void SaveToFile(string filePath);
    }
}
