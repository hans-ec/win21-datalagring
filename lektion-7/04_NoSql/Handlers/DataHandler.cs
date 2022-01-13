using _04_NoSql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_NoSql.Handlers
{
    internal abstract class DataHandler
    {
        protected string _databaseName;
        protected string _connectionString;

        public abstract Task AddAsync<T>(string collectionName, T record);
        public abstract Task<IEnumerable<T>> GetAsync<T>(string collectionName);
    }
}
