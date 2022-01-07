using _00_Sql_Dapper_Recap.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_Sql_Dapper_Recap.Services
{
    internal interface ICategoryService
    {
        void Create(Category category);
        Category Get(int id);
        IEnumerable<Category> GetAll();
    }

    internal class CategoryService : ICategoryService
    {
        private readonly string _connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\WIN21\win21-datalagring\lektion-5\00_Sql_Dapper_Recap\Data\sql_dapper_recap.mdf;Integrated Security=True;Connect Timeout=30";

        public void Create(Category category)
        {
            using (IDbConnection conn = new SqlConnection(_connectionstring))
            {
                conn.Execute("IF NOT EXISTS (SELECT Id FROM Categories WHERE Name = @Name) INSERT INTO Categories VALUES(@Name)", category);
            }
        }

        public Category Get(int id)
        {
            Category category = new();

            using (IDbConnection conn = new SqlConnection(_connectionstring))
            {
                category = conn.QueryFirstOrDefault<Category>("SELECT * FROM Categories WHERE Id = @Id", new { Id = id });
            }

            return category;
        }

        public IEnumerable<Category> GetAll()
        {
            var list = new List<Category>();

            using (IDbConnection conn = new SqlConnection(_connectionstring))
            {
                list = conn.Query<Category>("SELECT * FROM Categories").ToList();
            }

            return list;
        }
    }
}
