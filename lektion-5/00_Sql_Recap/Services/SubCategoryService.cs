using _00_Sql_Recap.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_Sql_Recap.Services
{
    internal interface ISubCategoryService
    {
        void Create(SubCategory subcategory);
        SubCategory Get(int id);
        IEnumerable<SubCategory> GetAll();
    }

    internal class SubCategoryService : ISubCategoryService
    {
        private readonly string _connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\WIN21\win21-datalagring\lektion-5\00_Sql_Recap\Data\sql_recap.mdf;Integrated Security=True;Connect Timeout=30";

        public void Create(SubCategory subcategory)
        {
            using (SqlConnection conn = new SqlConnection(_connectionstring))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("IF NOT EXISTS (SELECT Id FROM SubCategories WHERE Name = @Name) INSERT INTO SubCategories VALUES(@Name, @CategoryId)", conn))
                {
                    cmd.Parameters.AddWithValue("@Name", subcategory.Name);
                    cmd.Parameters.AddWithValue("@CategoryId", subcategory.CategoryId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public SubCategory Get(int id)
        {
            SubCategory subcategory = new();

            using (SqlConnection conn = new SqlConnection(_connectionstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT sc.Id, sc.Name, c.Name as Category FROM SubCategories sc JOIN Categories c ON c.Id = sc.CategoryId WHERE Id = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    var result = cmd.ExecuteReader();

                    while (result.Read())
                    {
                        subcategory = new SubCategory
                        {
                            Id = (int)result.GetValue(0),
                            Name = (string)result.GetValue(1),
                            Category = (string)result.GetValue(2)
                        };
                    }
                }
            }

            return subcategory;
        }

        public IEnumerable<SubCategory> GetAll()
        {
            var list = new List<SubCategory>();

            using (SqlConnection conn = new SqlConnection(_connectionstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT sc.Id, sc.Name, c.Name as Category FROM SubCategories sc JOIN Categories c ON c.Id = sc.CategoryId", conn))
                {
                    var result = cmd.ExecuteReader();

                    while (result.Read())
                    {
                        list.Add(new SubCategory
                        {
                            Id = (int)result.GetValue(0),
                            Name = (string)result.GetValue(1),
                            Category = (string)result.GetValue(2)
                        });
                    }
                }
            }

            return list;
        }
    }
}
