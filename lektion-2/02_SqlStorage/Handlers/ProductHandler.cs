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
    public interface IProductHandler : ISqlCommands
    {

    }

    public class ProductHandler : IProductHandler
    {
        private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\WIN21\win21-datalagring\lektion-2\02_SqlStorage\Data\sql_database.mdf;Integrated Security=True;Connect Timeout=30";


        public void Create(object obj)
        {
            var product = (Product)obj;

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("IF NOT EXISTS (SELECT Id FROM Products WHERE Name = @Name) INSERT INTO Products (Name, Description, StockPrice) VALUES (@Name, @Description, @StockPrice)", conn))
                {
                    cmd.Parameters.AddWithValue("@Name", product.Name);
                    cmd.Parameters.AddWithValue("@Description", product.Description);
                    cmd.Parameters.AddWithValue("@StockPrice", product.StockPrice);

                    cmd.ExecuteNonQuery();
                }

            }
        }

        public object Get(int id)
        {
            var product = new Product();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("SELECT * FROM Products WHERE Id = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    var result = cmd.ExecuteReader();

                    while (result.Read())
                    {
                        product.Id = (int)result.GetValue(0);
                        product.Name = (string)result.GetValue(1);
                        product.Description = (string)result.GetValue(2);
                        product.StockPrice = (decimal)result.GetValue(3);
                    }
                }
            }

            return product;
        }

        public IEnumerable<object> GetAll()
        {
            var products = new List<Product>();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("SELECT * FROM Products", conn))
                {
                    var result = cmd.ExecuteReader();

                    while (result.Read())
                    {
                        products.Add(new Product
                        {
                            Id = (int)result.GetValue(0),
                            Name = (string)result.GetValue(1),
                            Description = (string)result.GetValue(2),
                            StockPrice = (decimal)result.GetValue(3)
                        });
                    }
                }
            }

            return products;
        }
    }
}
