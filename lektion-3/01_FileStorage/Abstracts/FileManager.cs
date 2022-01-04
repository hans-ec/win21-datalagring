using _01_FileStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_FileStorage.Abstracts
{
    public abstract class FileManager
    {
        protected List<Customer> _customers = new List<Customer>();
        protected string _filePath;

        public void Add(Customer customer)
        {
            _customers.Add(customer);
        }

        public IEnumerable<Customer> Get()
        {
            return _customers;
        }

        public abstract void ReadFromFile();
        public abstract void WriteToFile();
    }
}
