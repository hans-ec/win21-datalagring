using _01_FileStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_FileStorage.Abstracts
{
    public class CsvAbstractHandler : FileStorage
    {
        public override void ReadFromFile(string filePath)
        {
            using (var sr = new StreamReader(filePath))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    var values = line.Split(";");

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

        public override void SaveToFile(string filePath)
        {
            using (var sw = new StreamWriter(filePath))
            {
                foreach (var customer in _customers)
                    sw.WriteLine($"{customer.Id};{customer.FirstName};{customer.LastName};{customer.Email}");
            }
        }
    }
}
