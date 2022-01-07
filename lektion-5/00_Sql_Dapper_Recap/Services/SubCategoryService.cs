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
    internal interface ISubCategoryService
    {
        void Create(SubCategory subcategory);
        SubCategory Get(int id);
        IEnumerable<SubCategory> GetAll();
    }

    internal class SubCategoryService : ISubCategoryService
    {
        private readonly string _connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\WIN21\win21-datalagring\lektion-5\00_Sql_Dapper_Recap\Data\sql_dapper_recap.mdf;Integrated Security=True;Connect Timeout=30";

        public void Create(SubCategory subcategory)
        {
            using (IDbConnection conn = new SqlConnection(_connectionstring))
            {
                conn.Execute("IF NOT EXISTS (SELECT Id FROM SubCategories WHERE Name = @Name) INSERT INTO SubCategories VALUES(@Name, @CategoryId)", subcategory);
            }
        }

        public SubCategory Get(int id)
        {
            SubCategory subcategory = new();

            using (IDbConnection conn = new SqlConnection(_connectionstring))
            {
                subcategory = conn.QueryFirstOrDefault<SubCategory>("SELECT sc.Id, sc.Name, c.Name as Category FROM SubCategories sc JOIN Categories c ON c.Id = sc.CategoryId WHERE Id = @Id", new { Id = id });
            }

            return subcategory;
        }

        public IEnumerable<SubCategory> GetAll()
        {
            var list = new List<SubCategory>();

            using (IDbConnection conn = new SqlConnection(_connectionstring))
            {
                list = conn.Query<SubCategory>("SELECT sc.Id, sc.Name, c.Name as Category FROM SubCategories sc JOIN Categories c ON c.Id = sc.CategoryId").ToList();
            }

            return list;
        }
    }
}
