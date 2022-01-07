using _00_Sql_Recap.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_Sql_Recap.Services
{
    internal interface ICategoryService
    {
        void Create(Category category);
        Category Get(int id);
        IEnumerable<Category> GetAll();
    }

    internal class CategoryService : ICategoryService
    {
        private readonly string _connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\WIN21\win21-datalagring\lektion-5\00_Sql_Recap\Data\sql_recap.mdf;Integrated Security=True;Connect Timeout=30";

        public void Create(Category category)
        {
            using (SqlConnection conn = new SqlConnection(_connectionstring))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("IF NOT EXISTS (SELECT Id FROM Categories WHERE Name = @Name) INSERT INTO Categories VALUES(@Name)", conn))
                {
                    cmd.Parameters.AddWithValue("@Name", category.Name);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Category Get(int id)
        {
            Category category = new();

            using (SqlConnection conn = new SqlConnection(_connectionstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Categories WHERE Id = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    var result = cmd.ExecuteReader();

                    while (result.Read())
                    {
                        category = new Category
                        {
                            Id = (int)result.GetValue(0),
                            Name = (string)result.GetValue(1)
                        };
                    }
                }
            }

            return category;
        }

        public IEnumerable<Category> GetAll()
        {
            var list = new List<Category>();

            using (SqlConnection conn = new SqlConnection(_connectionstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Categories", conn))
                {
                    var result = cmd.ExecuteReader();

                    while(result.Read())
                    {
                        list.Add(new Category
                        {
                            Id = (int)result.GetValue(0),
                            Name = (string)result.GetValue(1)
                        });
                    }
                }
            }

            return list;
        }
    }
}
