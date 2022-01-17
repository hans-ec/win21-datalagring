using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _00_AsyncAwait_WPF.Services
{
    internal class ExampleHandler
    {
        public string BlockingCode(string text)
        {
            Thread.Sleep(5000);
            text = $"{text} - är nu klar.";
            return text;
        }

        public async Task<string> NonBlockingCodeAsync(string text)
        {
            await Task.Delay(5000);
            text = $"{text} - är nu klar.";
            return text;
        }
    }
}
