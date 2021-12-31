using _02_SqlStorage.Interfaces;
using _02_SqlStorage.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_SqlStorage.Handlers
{
    public interface ICustomerHandler : ISqlCommands
    {

    }


    public class CustomerHandler : ICustomerHandler
    {
        private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\WIN21\win21-datalagring\lektion-2\02_SqlStorage\Data\sql_database.mdf;Integrated Security=True;Connect Timeout=30";

        public void Create(object obj)
        {
            var customer = (Customer)obj;

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("IF NOT EXISTS (SELECT Id FROM Customers WHERE Email = @Email) INSERT INTO Customers (FirstName, LastName, Email, Password) VALUES (@FirstName, @LastName, @Email, @Password)", conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                    cmd.Parameters.AddWithValue("@Email", customer.Email);
                    cmd.Parameters.AddWithValue("@Password", customer.Password);

                    cmd.ExecuteNonQuery();
                }

            }

        }

        public object Get(int id)
        {
            var customer = new Customer();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("SELECT Id, FirstName, LastName, Email FROM Customers WHERE Id = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    var result = cmd.ExecuteReader();

                    while (result.Read())
                    {
                        customer.Id = (int)result.GetValue(0);
                        customer.FirstName = (string)result.GetValue(1);
                        customer.LastName = (string)result.GetValue(2);
                        customer.Email = (string)result.GetValue(3);
                    }
                }
            }

            return customer;
        }

        public IEnumerable<object> GetAll()
        {
            var customers = new List<Customer>();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("SELECT Id, FirstName, LastName, Email FROM Customers", conn))
                {
                    var result = cmd.ExecuteReader();

                    while (result.Read())
                    {
                        customers.Add(new Customer
                        {
                            Id = (int)result.GetValue(0),
                            FirstName = (string)result.GetValue(1),
                            LastName = (string)result.GetValue(2),
                            Email = (string)result.GetValue(3)
                        });
                    }
                }
            }

            return customers;
        }
    }
}
