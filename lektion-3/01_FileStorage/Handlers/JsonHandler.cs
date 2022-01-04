using _01_FileStorage.Abstracts;
using _01_FileStorage.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_FileStorage.Handlers
{
    public class JsonHandler : FileManager
    {
        public JsonHandler(string filePath)
        {
            _filePath = filePath;
        }


        public override void ReadFromFile()
        {
            using var sr = new StreamReader(_filePath);
            _customers = JsonConvert.DeserializeObject<List<Customer>>(sr.ReadToEnd());
        }

        public override void WriteToFile()
        {
            using var sw = new StreamWriter(_filePath);
            sw.WriteLine(JsonConvert.SerializeObject(_customers));
        }
    }
}
