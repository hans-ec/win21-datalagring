using _02_SqlStorage.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_SqlStorage.Handlers
{
    internal class DapperManager : SqlHandler
    {
        public DapperManager(string connectionstring)
        {
            _connectionString = connectionstring;
        }

        public override void Add(UserModel user)
        {
            using(IDbConnection conn = new SqlConnection(_connectionString))
            {
                conn.Execute("INSERT INTO Users VALUES (@Id, @FirstName, @LastName, @Email)", user);
            }
        }

        public override IEnumerable<UserModel> Get()
        {
            var list = new List<UserModel>();

            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                list = conn.Query<UserModel>("SELECT * FROM Users").ToList();
            }

            return list;
        }
    }
}
