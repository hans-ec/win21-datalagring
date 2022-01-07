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
    internal interface IProductService
    {
        void Create(Product product);
        Product Get(int id);
        IEnumerable<Product> GetAll();
    }

    internal class ProductService : IProductService
    {
        private readonly string _connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\WIN21\win21-datalagring\lektion-5\00_Sql_Dapper_Recap\Data\sql_dapper_recap.mdf;Integrated Security=True;Connect Timeout=30";

        public void Create(Product product)
        {
            using (IDbConnection conn = new SqlConnection(_connectionstring))
            {
                conn.Execute("IF NOT EXISTS (SELECT Id FROM Products WHERE Name = @Name) INSERT INTO Products VALUES(@Name, @Description, @Price, @SubCategoryId)", product);
            }
        }

        public Product Get(int id)
        {
            Product product = new();

            using (IDbConnection conn = new SqlConnection(_connectionstring))
            {
                product = conn.QueryFirstOrDefault<Product>("SELECT p.Id, p.Name, p.Description, p.Price, sc.Name as SubCategory, c.Name as Category FROM Products p JOIN SubCategories sc ON sc.Id = p.SubCategoryId JOIN Categories c ON c.Id = sc.CategoryId WHERE Id = @Id", new { Id = id });
            }

            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            var list = new List<Product>();

            using (IDbConnection conn = new SqlConnection(_connectionstring))
            {
                list = conn.Query<Product>("SELECT p.Id, p.Name, p.Description, p.Price, sc.Name as SubCategory, c.Name as Category FROM Products p JOIN SubCategories sc ON sc.Id = p.SubCategoryId JOIN Categories c ON c.Id = sc.CategoryId").ToList();
            }

            return list;
        }
    }
}
