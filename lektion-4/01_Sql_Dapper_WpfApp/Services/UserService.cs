using _01_Sql_Dapper_WpfApp.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Sql_Dapper_WpfApp.Services
{
    internal interface IUserService
    {
        bool CreateUser(User user);
        IEnumerable<User> GetUsers();
    }
    internal class UserService : IUserService
    {
        private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\WIN21\win21-datalagring\lektion-4\01_Sql_Dapper_WpfApp\Data\sql_dapper_wpf.mdf;Integrated Security=True;Connect Timeout=30";

        public bool CreateUser(User user)
        {
            try
            {
                var _user = GetUserByEmail(user.Email);
                if (_user == null)
                {           
                        using IDbConnection conn = new SqlConnection(_connectionString);
                        var userId = conn.ExecuteScalar("INSERT INTO Users OUTPUT inserted.Id VALUES(@FirstName, @LastName, @Email)", user);
                        return true;
                }
            }
            catch { }

            return false;
        }

        public IEnumerable<User> GetUsers()
        {
            using IDbConnection conn = new SqlConnection(_connectionString);
            return conn.Query<User>("SELECT * FROM Users");
        }

        private User GetUserByEmail(string email)
        {
            using IDbConnection conn = new SqlConnection(_connectionString);
            return conn.QueryFirstOrDefault<User>("SELECT * FROM Users WHERE Email = @Email", new { Email = email });
        }
    }
}
