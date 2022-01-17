using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_FileStorage.Services
{
    internal abstract class FileHandler
    {
        public virtual async Task SaveToFileAsync<T>(T list, string filePath)
        {
            using var sw = new StreamWriter(filePath);
            await sw.WriteLineAsync(JsonConvert.SerializeObject(list));
            sw.Close();
        }

        public virtual async Task<List<T>> ReadFromFileAsync<T>(string filePath)
        {
            using var sr = new StreamReader(filePath);
            var list = JsonConvert.DeserializeObject<List<T>>(await sr.ReadToEndAsync());
            sr.Close();

            return list;
        }
    }
}
