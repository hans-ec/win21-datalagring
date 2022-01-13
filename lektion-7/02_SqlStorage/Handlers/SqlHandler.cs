using _02_SqlStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_SqlStorage.Handlers
{
    internal abstract class SqlHandler
    {
        protected string _connectionString;

        public abstract void Add(UserModel user);
        public abstract IEnumerable<UserModel> Get();

    }
}
