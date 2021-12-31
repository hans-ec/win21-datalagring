using _01_FileStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_FileStorage.Interfaces
{
    public interface IFileStorage
    {
        void SaveToFile(string filePath, string delimiter = ";");
        void ReadFromFile(string filePath, string delimiter = ";");
        void AddToList(Customer customer);
        List<Customer> Customers();
    }
}
