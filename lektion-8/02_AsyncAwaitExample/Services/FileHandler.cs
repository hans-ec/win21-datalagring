using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02_AsyncAwaitExample.Services
{
    internal class FileHandler
    {
        public async Task<string> ExampleAsync()
        {
            await Task.Delay(5000);
            return "klart";
        }

        public string Example()
        {
            Thread.Sleep(5000);
            return "klart";
        }


        public async Task<List<T>> GetListAsync<T>(string filePath)
        {
            using var sr = new StreamReader(filePath);
            var list = JsonConvert.DeserializeObject<List<T>>(await sr.ReadToEndAsync());

            return list;
        }
    }
}
