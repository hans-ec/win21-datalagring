using _01_FileStorage.Interfaces;
using _01_FileStorage.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_FileStorage.Handlers
{
    public interface IJsonHandler : IFileStorage
    {

    }

    public class JsonHandler : IJsonHandler
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
                _customers = JsonConvert.DeserializeObject<List<Customer>>(sr.ReadToEnd());
            }
        }

        public void SaveToFile(string filePath, string delimiter = ";")
        {
            using (var sw = new StreamWriter(filePath))
            {
                sw.WriteLine(JsonConvert.SerializeObject(_customers));
            }
        }
    }
}
