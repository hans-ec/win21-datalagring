using _01_FileStorage.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_FileStorage.Handlers
{
    internal class JsonFileManager : FileHandler
    {
        public JsonFileManager(string filePath)
        {
            _filePath = filePath;
        }

        public override void ReadFromFile()
        {
            try
            {
                using var sr = new StreamReader(_filePath);
                _users = JsonConvert.DeserializeObject<List<UserModel>>(sr.ReadToEnd());
                sr.Close();
            }
            catch { }
        }

        public override void WriteToFile()
        {
            try
            {
                using var sw = new StreamWriter(_filePath);
                sw.WriteLine(JsonConvert.SerializeObject(_users));
                sw.Close();
            }
            catch { }
        }
    }
}
