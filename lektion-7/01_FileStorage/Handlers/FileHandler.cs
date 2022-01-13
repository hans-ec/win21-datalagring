using _01_FileStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_FileStorage.Handlers
{
    internal abstract class FileHandler
    {
        protected List<UserModel> _users = new();
        protected string _filePath;

        public virtual void Add(UserModel user) { _users.Add(user); }
        public virtual IEnumerable<UserModel> Get() { return _users; }
        public abstract void ReadFromFile();
        public abstract void WriteToFile();
    }
}
