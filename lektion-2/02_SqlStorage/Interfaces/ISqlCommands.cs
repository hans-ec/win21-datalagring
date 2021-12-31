using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_SqlStorage.Interfaces
{
    public interface ISqlCommands
    {
        void Create(object obj);
        object Get(int id);
        IEnumerable<object> GetAll();
    }
}
