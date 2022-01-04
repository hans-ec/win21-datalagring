using _03_SqlStorage_Dapper.Abstracts;
using _03_SqlStorage_Dapper.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_SqlStorage_Dapper.Handlers
{
    //          Skapar    Hämtar    Uppdaterar   Tar bort
    //-----------------------------------------------------
    // CRUD     Create    Read      Update       Delete
    // HTTP     POST      GET       PUT          DELETE
    // SQL      INSERT    SELECT    UPDATE       DELETE




    public class UserHandler
    {
        private string _connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\WIN21\win21-datalagring\lektion-3\03_SqlStorage_Dapper\Data\sql_dapper_db.mdf;Integrated Security=True;Connect Timeout=30";

        public int Create(User user)
        {
            int result = 0;

            using (IDbConnection conn = new SqlConnection(_connectionstring))
            {
                try
                {
                    user.AddressId = (int)conn.ExecuteScalar("IF NOT EXISTS (SELECT Id FROM Addresses WHERE StreetName = @StreetName AND PostalCode = @PostalCode) INSERT INTO Addresses OUTPUT inserted.Id VALUES (@StreetName, @PostalCode, @City) ELSE SELECT Id FROM Addresses WHERE StreetName = @StreetName AND PostalCode = @PostalCode", user);
                    result = conn.Execute("IF NOT EXISTS (SELECT Id FROM Users WHERE Email = @Email) INSERT INTO Users OUTPUT inserted.Id VALUES (@FirstName, @LastName, @Email, @AddressId) ELSE SELECT 0 FROM Users", user);
                }
                catch
                {
                    Console.WriteLine("Gick inte att skapa en användare. Kan bero på att det redan finns en användare.");
                }         
            }

            return result;
        }

        public IEnumerable<User> ReadAll()
        {
            var result = new List<User>();

            using (IDbConnection conn = new SqlConnection(_connectionstring))
            {
                result = conn.Query<User>("SELECT u.Id,u.FirstName,u.LastName,u.Email,u.AddressId,a.StreetName,a.PostalCode,a.City FROM Users u JOIN Addresses a ON a.Id = u.AddressId").ToList();                
            }

            return result;
        }

        public User Read(int id)
        {
            var user = new User();

            using (IDbConnection conn = new SqlConnection(_connectionstring))
            {
                user = conn.QueryFirstOrDefault<User>("SELECT * FROM Users WHERE Id = @Id", new { Id = id });
            }

            return user;
        }

        public void Update(User user)
        {
            using (IDbConnection conn = new SqlConnection(_connectionstring))
            {
                user.AddressId = (int)conn.ExecuteScalar("IF NOT EXISTS (SELECT Id FROM Addresses WHERE StreetName = @StreetName AND PostalCode = @PostalCode) INSERT INTO Addresses OUTPUT inserted.Id VALUES (@StreetName, @PostalCode, @City) ELSE SELECT Id FROM Addresses WHERE StreetName = @StreetName AND PostalCode = @PostalCode", user);
                conn.Execute("UPDATE Users SET FirstName = @FirstName, LastName = @LastName, Email = @Email, AddressId = @AddressId WHERE Id = @Id", user);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection conn = new SqlConnection(_connectionstring))
            {
                conn.Execute("DELETE FROM Users WHERE Id = @Id", new { Id = id });
            }
        }
    }
}
