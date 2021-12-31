using _01_FileStorage.Interfaces;
using _01_FileStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_FileStorage.Handlers
{
    public interface ICsvHandler : IFileStorage
    {

    }

    public class CsvHandler : ICsvHandler
    {
        private List<Customer> _customers = new List<Customer>();


        public void AddToList(Customer customer)
        {
            _customers.Add(customer);
        }

        public List<Customer> Customers()
        {
            return _customers;
        }

        public void ReadFromFile(string filePath, string delimiter = ";")
        {
            using (var sr = new StreamReader(filePath))
            {
                string line;

                while((line = sr.ReadLine())  != null)
                {
                    var values = line.Split(delimiter);

                    _customers.Add(new Customer
                    {
                        Id = int.Parse(values[0]),
                        FirstName = values[1],
                        LastName = values[2],
                        Email = values[3]
                    });
                }
            }
        }

        public void SaveToFile(string filePath, string delimiter = ";")
        {
            using (var sw = new StreamWriter(filePath))
            {
                foreach (var customer in _customers)
                    sw.WriteLine($"{customer.Id}{delimiter}{customer.FirstName}{delimiter}{customer.LastName}{delimiter}{customer.Email}");
            }
        }
    }
}
