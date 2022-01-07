using _00_Sql_Recap.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_Sql_Recap.Services
{
    internal interface IProductService
    {
        void Create(Product product);
        Product Get(int id);
        IEnumerable<Product> GetAll();
    }

    internal class ProductService : IProductService
    {
        private readonly string _connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\WIN21\win21-datalagring\lektion-5\00_Sql_Recap\Data\sql_recap.mdf;Integrated Security=True;Connect Timeout=30";

        public void Create(Product product)
        {
            using (SqlConnection conn = new SqlConnection(_connectionstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("IF NOT EXISTS (SELECT Id FROM Products WHERE Name = @Name) INSERT INTO Products VALUES (@Name, @Description, @Price, @SubCategoryId)", conn))
                {
                    cmd.Parameters.AddWithValue("@Name", product.Name);
                    cmd.Parameters.AddWithValue("@Description", product.Description);
                    cmd.Parameters.AddWithValue("@Price", product.Price);
                    cmd.Parameters.AddWithValue("@SubCategoryId", product.SubCategoryId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Product Get(int id)
        {
            Product product = new();

            using (SqlConnection conn = new SqlConnection(_connectionstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT p.Id, p.Name, p.Description, p.Price, sc.Name as SubCategory, c.Name as Category FROM Products p JOIN SubCategories sc ON sc.Id = p.SubCategoryId JOIN Categories c ON c.Id = sc.CategoryId WHERE Id = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    var result = cmd.ExecuteReader();

                    while (result.Read())
                    {
                        product = new Product
                        {
                            Id = (int)result.GetValue(0),
                            Name = (string)result.GetValue(1),
                            Description = (string)result.GetValue(2),
                            Price = (decimal)result.GetValue(3),
                            SubCategory = (string)result.GetValue(4),
                            Category = (string)result.GetValue(5)
                        };
                    }
                }
            }

            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            var list = new List<Product>();

            using (SqlConnection conn = new SqlConnection(_connectionstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT p.Id, p.Name, p.Description, p.Price, sc.Name as SubCategory, c.Name as Category FROM Products p JOIN SubCategories sc ON sc.Id = p.SubCategoryId JOIN Categories c ON c.Id = sc.CategoryId", conn))
                {
                    var result = cmd.ExecuteReader();

                    while (result.Read())
                    {
                        list.Add(new Product
                        {
                            Id = (int)result.GetValue(0),
                            Name = (string)result.GetValue(1),
                            Description = (string)result.GetValue(2),
                            Price = (decimal)result.GetValue(3),
                            SubCategory = (string)result.GetValue(4),
                            Category = (string)result.GetValue(5)
                        });
                    }
                }
            }

            return list;
        }
    }
}
