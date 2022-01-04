using _01_FileStorage.Abstracts;
using _01_FileStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_FileStorage.Handlers
{
    public class CsvHandler : FileManager
    {
        public CsvHandler(string filePath)
        {
            _filePath = filePath;
        }


        public override void ReadFromFile()
        {
            using var sr = new StreamReader(_filePath);
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                var values = line.Split(";");
                _customers.Add(new Customer { Id = values[0], FirstName = values[1], LastName = values[2], Email = values[3] });
            }
        }

        public override void WriteToFile()
        {
            using var sw = new StreamWriter(_filePath);
            foreach(var customer in _customers)
                sw.WriteLine($"{customer.Id};{customer.FirstName};{customer.LastName};{customer.Email}");
        }
    }
}
