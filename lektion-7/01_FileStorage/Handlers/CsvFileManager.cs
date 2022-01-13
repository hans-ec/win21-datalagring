using _01_FileStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_FileStorage.Handlers
{
    internal class CsvFileManager : FileHandler
    {
        private readonly string _delimiter;

        public CsvFileManager(string filePath, string delimiter = ";")
        {
            _filePath = filePath;
            _delimiter = delimiter;
        }

        public override void ReadFromFile()
        {
            try
            {
                using var sr = new StreamReader(_filePath);
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    var values = line.Split(_delimiter);
                    _users.Add(new UserModel { Id = values[0], Name = values[1], Email = values[2] });
                }
            }
            catch { }
        }

        public override void WriteToFile()
        {
            try
            {
                using var sw = new StreamWriter(_filePath);
                foreach (var user in _users)
                    sw.WriteLine($"{user.Id}{_delimiter}{user.Name}{_delimiter}{user.Email}");
            }
            catch { }
        }
    }
}
