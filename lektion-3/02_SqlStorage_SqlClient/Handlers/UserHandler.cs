using _02_SqlStorage_SqlClient.Abstracts;
using _02_SqlStorage_SqlClient.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_SqlStorage_SqlClient.Handlers
{
    public class UserHandler : SqlManager
    {
        public int CreateUser(User user)
        {
            var dictionary = new Dictionary<string, object>
            {
                { "@FirstName", user.FirstName },
                { "@LastName", user.LastName },
                { "@Email", user.Email },
                { "@StreetName", user.Address.StreetName },
                { "@PostalCode", user.Address.PostalCode },
                { "@City", user.Address.City }

            };

            var addressId = (int)ExecuteScalar("IF NOT EXISTS (SELECT Id FROM Addresses WHERE StreetName = @StreetName AND PostalCode = @PostalCode) INSERT INTO Addresses OUTPUT inserted.Id VALUES (@StreetName, @PostalCode, @City) ELSE SELECT Id FROM Addresses WHERE StreetName = @StreetName AND PostalCode = @PostalCode", dictionary);
            dictionary.Add("AddressId", addressId);

            return (int)ExecuteScalar("IF NOT EXISTS (SELECT Id FROM Users WHERE Email = @Email) IF EXISTS (SELECT Id FROM Addresses WHERE Id = @AddressId) INSERT INTO Users OUTPUT inserted.Id VALUES (@FirstName, @LastName, @Email, @AddressId)", dictionary);
        }

        public IEnumerable<User> GetUsers()
        {
            return (IEnumerable<User>)ExecuteReader("SELECT * FROM Users");
        }


        protected override IEnumerable<object> ExecuteReader(string sqlQuery)
        {
            var list = new List<User>();

            using (var _conn = new SqlConnection(_connectionString))
            {
                _conn.Open();
                using var cmd = new SqlCommand(sqlQuery, _conn);

                var result = cmd.ExecuteReader();
                while(result.Read())
                {
                    list.Add(new User
                    {
                        Id = (int)result.GetValue(0),
                        FirstName = (string)result.GetValue(1),
                        LastName = (string)result.GetValue(2),
                        Email = (string)result.GetValue(3)
                    });
                }                
            }

            return list;
        }
    }
}
