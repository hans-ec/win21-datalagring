using _00_Dapper_Recap.Entitites;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_Dapper_Recap.Handlers
{
    internal class SqlHandler
    {
        private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\WIN21\win21-datalagring\lektion-4\00_Dapper_Recap\Data\sql_dapper_recap.mdf;Integrated Security=True;Connect Timeout=30";

        public IEnumerable<User> GetUsers()
        {
            using IDbConnection conn = new SqlConnection(_connectionString);
            return conn.Query<User>("SELECT * FROM Users");
        }

        public User GetUserByEmail(string email)
        {
            using IDbConnection conn = new SqlConnection(_connectionString);
            return conn.QueryFirstOrDefault<User>("SELECT * FROM Users WHERE Email = @Email", new { Email = email });
        }

        public User GetUser(int id)
        {
            using IDbConnection conn = new SqlConnection(_connectionString);
            return conn.QueryFirstOrDefault<User>("SELECT * FROM Users WHERE Id = @Id", new { Id = id });
        }

        public bool CreateUser(User user)
        {
            try
            {
                using IDbConnection conn = new SqlConnection(_connectionString);
                var userId = conn.ExecuteScalar("INSERT INTO Users OUTPUT inserted.Id VALUES(@FirstName, @LastName, @Email)", user);
                return true;
            }
            catch { }

            return false;
        }

    }
}
