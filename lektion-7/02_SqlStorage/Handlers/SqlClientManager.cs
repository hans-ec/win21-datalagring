using _02_SqlStorage.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_SqlStorage.Handlers
{
    internal class SqlClientManager : SqlHandler
    {
        public SqlClientManager(string connectionstring)
        {
            _connectionString = connectionstring;
        }

        public override void Add(UserModel user)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Users VALUES (@Id, @FirstName, @LastName, @Email)", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", user.Id);
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public override IEnumerable<UserModel> Get()
        {
            var list = new List<UserModel>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Users", conn))
                {
                    var result = cmd.ExecuteReader();
                    while(result.Read())
                    {
                        list.Add(new UserModel
                        {
                            Id = new Guid(result.GetValue(0).ToString()),
                            FirstName = (string)result.GetValue(1),
                            LastName = (string)result.GetValue(2),
                            Email = (string)result.GetValue(3)
                        });
                    }
                }
            }

            return list;
        }
    }
}
