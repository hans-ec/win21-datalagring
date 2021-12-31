using _01_FileStorage.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_FileStorage.Abstracts
{
    public class JsonAbstractHandler : FileStorage
    {
        public override void ReadFromFile(string filePath)
        {
            using (var sr = new StreamReader(filePath))
            {
                _customers = JsonConvert.DeserializeObject<List<Customer>>(sr.ReadToEnd());
            }
        }

        public override void SaveToFile(string filePath)
        {
            using (var sw = new StreamWriter(filePath))
            {
                sw.WriteLine(JsonConvert.SerializeObject(_customers));
            }
        }
    }
}
